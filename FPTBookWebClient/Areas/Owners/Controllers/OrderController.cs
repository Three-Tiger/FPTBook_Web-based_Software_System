using BusinessObjects;
using FPTBookWebClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Areas.Owners.Controllers
{
	[Authorize(Roles = "Owner")]
	[Area("Owners")]
	public class OrderController : Controller
    {
		private readonly IConfiguration _configuration;
		private readonly HttpClient client = null;
		private string api;
		public OrderController(IConfiguration configuration)
		{
			_configuration = configuration;
			client = new HttpClient();
			client.BaseAddress = new Uri(_configuration["BaseAddress"]);
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "/api/Orders";
		}

		public async Task<IActionResult> Index()
        {
			ViewData["api"] = _configuration["BaseAddress"];

			HttpResponseMessage httpResponse = await client.GetAsync(api);
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Order> orders = JsonSerializer.Deserialize<List<Order>>(data, options);
			DisplayOrderView displayOrder = new DisplayOrderView()
			{
				Orders = orders,
			};
			return View(displayOrder);
        }
    }
}
