using BusinessObjects;
using FPTBookWebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Controllers
{
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

		[HttpPost]
		public async Task<IActionResult> Send(Contact obj)
		{
			ViewData["api"] = _configuration["BaseAddress"];

			string data = JsonSerializer.Serialize(obj);
			var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PostAsync(api, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Contact", "Home");
			}
			return RedirectToAction("Contact", "Home", obj);
		}
	}
}
