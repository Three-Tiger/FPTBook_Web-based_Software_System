using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Controllers
{
	[Authorize(Roles = "User")]
	public class FeedbackController : Controller
	{
		private readonly IConfiguration _configuration;
		private readonly UserManager<AppUser> _userManager;

		private readonly HttpClient client = null;
		private string api;
		public FeedbackController(UserManager<AppUser> userManager, IConfiguration configuration)
		{
			_configuration = configuration;
			client = new HttpClient();
			client.BaseAddress = new Uri(_configuration["BaseAddress"]);
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "/api/Feedbacks";

			_userManager = userManager;
		}

		public IActionResult Index(int bookId)
		{
			ViewData["BookId"] = bookId;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Give(int id, Feedback feedback)
		{
			string userId = _userManager.GetUserId(User);
			feedback.UserId = userId;
			feedback.BookId = id;
			string data = JsonSerializer.Serialize(feedback);
			var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
			await client.PostAsync(api, content);
			return RedirectToAction("Index", "PurchaseHistory");
		}
	}
}
