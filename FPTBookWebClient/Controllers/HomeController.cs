using BusinessObjects;
using FPTBookWebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Controllers
{
	public class HomeController : Controller
	{
		private readonly HttpClient _httpClient = null;
		private string api;

		public HomeController()
		{
			_httpClient = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			_httpClient.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "https://localhost:7076/api/Homes";
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Shop()
		{
			return View();
		}

		public async Task<IActionResult> Detail(int id)
		{
			HttpResponseMessage response = await _httpClient.GetAsync(api + "/Detail/" + id);
			if (response.IsSuccessStatusCode)
			{
				var data = response.Content.ReadAsStringAsync().Result;
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				Book obj = JsonSerializer.Deserialize<Book>(data, options);
				return View(obj);
			}
			return NotFound();
		}

		public IActionResult About()
		{
			return View();
		}
	}
}