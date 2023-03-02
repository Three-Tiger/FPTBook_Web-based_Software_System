using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Areas.Owners.Controllers
{
	[Authorize(Roles = "Owner")]
	[Area("Owners")]
	public class ContactController : Controller
	{
		private readonly IConfiguration _configuration;
		private readonly HttpClient client = null;
		private string api;
		public ContactController(IConfiguration configuration)
		{
			_configuration = configuration;
			client = new HttpClient();
			client.BaseAddress = new Uri(_configuration["BaseAddress"]);
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "/api/Contacts";
		}
		public async Task<IActionResult> Index()
		{
			HttpResponseMessage httpResponse = await client.GetAsync(api);
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Contact> contacts = JsonSerializer.Deserialize<List<Contact>>(data, options);
			return View(contacts);
		}

		public async Task<IActionResult> Update(int id)
		{
			HttpResponseMessage reponse = await client.GetAsync(api + "/" + id);
			if (reponse.IsSuccessStatusCode)
			{
				var data = reponse.Content.ReadAsStringAsync().Result;
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				var obj = JsonSerializer.Deserialize<Contact>(data, options);
				return View("Reply", obj);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> Update(int id, Contact contact)
		{
			contact.ContactId = id;
			string data = JsonSerializer.Serialize<Contact>(contact);
			var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PutAsync(api + "/" + id, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View(contact);
		}

		public async Task<IActionResult> Delete(int id)
		{
			HttpResponseMessage reponse = await client.DeleteAsync(api + "/" + id);
			if (reponse.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return NotFound();
		}
	}
}