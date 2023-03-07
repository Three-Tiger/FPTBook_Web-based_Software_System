using BusinessObjects;
using BusinessObjects.Constraints;
using FPTBookWebClient.Areas.Admins.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Areas.Admins.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admins")]
    public class OwnerController : Controller
    {
		private readonly IConfiguration _configuration;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;
		private readonly IUserStore<AppUser> _userStore;
		private readonly IUserEmailStore<AppUser> _emailStore;
		private readonly IPasswordHasher<AppUser> _passwordHash;

		private readonly HttpClient client = null;
		private string api;
		public OwnerController(UserManager<AppUser> userManager, IUserStore<AppUser> userStore, SignInManager<AppUser> signInManager, IPasswordHasher<AppUser> passwordHash, IConfiguration configuration)
		{
			_configuration = configuration;
			client = new HttpClient();
			client.BaseAddress = new Uri(_configuration["BaseAddress"]);
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "/api/Users";

			_userManager = userManager;
			_userStore = userStore;
			_emailStore = GetEmailStore();
			_signInManager = signInManager;
			_passwordHash = passwordHash;
		}


		public async Task<IActionResult> Index()
		{
			HttpResponseMessage httpResponse = await client.GetAsync(api + "/Owners");
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<AppUser> appuser = JsonSerializer.Deserialize<List<AppUser>>(data, options);
			return View(appuser);
		}

	
		public ActionResult Create()
		{
			return View();
		}

		private AppUser CreateUser()
		{
			try
			{
				return Activator.CreateInstance<AppUser>();
			}
			catch
			{
				throw new InvalidOperationException($"Can't create an instance of '{nameof(AppUser)}'. " +
					$"Ensure that '{nameof(AppUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
					$"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
			}
		}

		private IUserEmailStore<AppUser> GetEmailStore()
		{
			if (!_userManager.SupportsUserEmail)
			{
				throw new NotSupportedException("The default UI requires a user store with email support.");
			}
			return (IUserEmailStore<AppUser>)_userStore;
		}

		[HttpPost]
		public async Task<IActionResult> Create(User addUser)
		{
			if (ModelState.IsValid)
			{
				var user = CreateUser();
				user.FirstName = addUser.FirstName;
				user.LastName = addUser.LastName;
				user.Gender = addUser.Gender;
				if (addUser.Birthday < DateTime.Now)
				{
					user.Birthday = addUser.Birthday;
				}
				else
				{
					return View(addUser);
				}
				user.Address = addUser.Address;
				user.PhoneNumber = addUser.PhoneNumber;
				await _userStore.SetUserNameAsync(user, addUser.Email, CancellationToken.None);
				await _emailStore.SetEmailAsync(user, addUser.Email, CancellationToken.None);
				var result = await _userManager.CreateAsync(user, addUser.Password);

				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, Roles.Owner.ToString());
					return RedirectToAction("Index");
				}

			}
			return View(addUser);
		}


		public async Task<IActionResult> Edit(string id)
		{
			HttpResponseMessage reponse = await client.GetAsync(api + "/Account/" + id);
			if (reponse.IsSuccessStatusCode)
			{
				var data = reponse.Content.ReadAsStringAsync().Result;
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				var obj = JsonSerializer.Deserialize<AppUser>(data, options);
				return View(obj);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> Edit(string id, User user)
		{
			AppUser appUser = await _userManager.FindByIdAsync(id);
			if (appUser != null)
			{

				if (!string.IsNullOrEmpty(user.Password))
				{
					appUser.PasswordHash = _passwordHash.HashPassword(appUser, user.Password);
				}
				else
				{
					ModelState.AddModelError("", "Password cannot be empty");
				}

				if (!string.IsNullOrEmpty(user.Password))
				{
					IdentityResult result = await _userManager.UpdateAsync(appUser);
					if (result.Succeeded)
					{
						return RedirectToAction("Index");
					}
					else
					{
						Errors(result);
					}
				}
			}
			return RedirectToAction("Index");
		}

		private void Errors(IdentityResult result)
		{
			foreach (IdentityError error in result.Errors)
				ModelState.AddModelError("", error.Description);
		}
	}
}
