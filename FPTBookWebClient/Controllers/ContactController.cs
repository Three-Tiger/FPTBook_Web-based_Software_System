using BusinessObjects;
using FPTBookWebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Controllers
{
	public class ContactController : Controller
	{
		private readonly HttpClient client = null;
		private string api;
		public ContactController()
		{
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "https://localhost:7076/api/Contacts";
		}

		[HttpPost]
		public async Task<IActionResult> Send(ShowIndexView obj)
		{
			Contact contact = obj.Contact;
			string data = JsonSerializer.Serialize(contact);
			var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PostAsync(api, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Home");
			}
			return RedirectToAction("Index", "Home", obj);
		}
	}
}
