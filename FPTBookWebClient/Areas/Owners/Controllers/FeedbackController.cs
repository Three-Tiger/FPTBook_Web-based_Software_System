using BusinessObjects;
using BusinessObjects.Constraints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Areas.Owners.Controllers
{
    [Authorize(Roles = "Owner")]
    [Area("Owners")]
    public class FeedbackController : Controller
    {
		private readonly IConfiguration _configuration;
		private readonly HttpClient client = null;
		private string api;
		public FeedbackController(IConfiguration configuration)
		{
			_configuration = configuration;
			client = new HttpClient();
			client.BaseAddress = new Uri(_configuration["BaseAddress"]);
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "/api/Feedbacks";
		}

		public async Task<IActionResult> Index()
		{
			HttpResponseMessage httpResponse = await client.GetAsync(api);
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Feedback> feedbacks = JsonSerializer.Deserialize<List<Feedback>>(data, options);

			return View(feedbacks);
		}

		public async Task<IActionResult> Accept(int id)
		{
			HttpResponseMessage reponseGetFeedback = await client.GetAsync(api + "/" + id);
			var dataGetFeedback = reponseGetFeedback.Content.ReadAsStringAsync().Result;
			var optionsGetFeedback = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			var feedback = JsonSerializer.Deserialize<Feedback>(dataGetFeedback, optionsGetFeedback);

			string data = JsonSerializer.Serialize<Feedback>(feedback);
			var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

			if (feedback.FeedStatus == FeedStatus.Unchecked)
			{
				HttpResponseMessage response = await client.PutAsync(api + "/" + id + "/Checked", content);
				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
			}
			else
			{
				HttpResponseMessage response = await client.PutAsync(api + "/" + id + "/UnChecked", content);
				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
			}
			return NotFound();
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
