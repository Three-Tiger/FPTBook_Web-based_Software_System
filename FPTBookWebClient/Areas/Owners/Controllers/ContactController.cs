using BusinessObjects;
using EmailService;
using Microsoft.AspNetCore.Authorization;
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
		private string apiEmail;

		public ContactController(IConfiguration configuration)
		{
			_configuration = configuration;
			client = new HttpClient();
			client.BaseAddress = new Uri(_configuration["BaseAddress"]);
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "/api/Contacts";
			this.apiEmail = "/api/Emails";
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
			try
			{
				HttpResponseMessage reponse = await client.GetAsync(api + "/" + id);
				if (reponse.IsSuccessStatusCode)
				{
					var data = reponse.Content.ReadAsStringAsync().Result;
					var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
					var obj = JsonSerializer.Deserialize<Contact>(data, options);
					return View("Reply", obj);
				}
				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				return RedirectToAction("Index");
			}
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
				string dataReply = JsonSerializer.Serialize(new Message(contact.ContactEmail, "Reply your contact", contact.Reply));
				var contentReply = new StringContent(dataReply, System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage responseReply = await client.PostAsync(apiEmail, contentReply);
				if (responseReply.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
			}
			return View("Reply", contact);
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