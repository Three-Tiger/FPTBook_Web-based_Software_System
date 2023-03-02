using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Areas.Admins.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admins")]
	public class ApproveController : Controller
	{
		private readonly IConfiguration _configuration;
		private readonly HttpClient client = null;
		private string api;
		public ApproveController(IConfiguration configuration)
		{
			_configuration = configuration;
			client = new HttpClient();
			client.BaseAddress = new Uri(_configuration["BaseAddress"]);
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "/api/Genres";
		}


		public async Task<IActionResult> Index()
		{
			ViewData["api"] = _configuration["BaseAddress"];
			HttpResponseMessage httpResponse = await client.GetAsync(api);
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Genre> genres = JsonSerializer.Deserialize<List<Genre>>(data, options);
			return View(genres);
		}

		public async Task<IActionResult> AppGenre(int id)
		{
			HttpResponseMessage httpResponse = await client.GetAsync(api + "/" + id);
			string dataGetGenre = httpResponse.Content.ReadAsStringAsync().Result;
			var optionGetGenre = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			var genre = JsonSerializer.Deserialize<Genre>(dataGetGenre, optionGetGenre);

			string data = JsonSerializer.Serialize<Genre>(genre);
			var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

			HttpResponseMessage message = await client.PutAsync(api + "/Approvel/" + id, content);
			if (message.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return NotFound();
		}

		public async Task<IActionResult> Reject(int id)
		{
			HttpResponseMessage httpResponse = await client.GetAsync(api + "/" + id);
			string dataGetGenre = httpResponse.Content.ReadAsStringAsync().Result;
			var optionGetGenre = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			var genre = JsonSerializer.Deserialize<Genre>(dataGetGenre, optionGetGenre);

			string data = JsonSerializer.Serialize<Genre>(genre);
			var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

			HttpResponseMessage message = await client.PutAsync(api + "/Reject/" + id, content);
			if (message.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return NotFound();
		}
	}
}
