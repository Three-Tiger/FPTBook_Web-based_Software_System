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
		private readonly HttpClient client = null;
		private string api;
		public OrderController()
		{
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "https://localhost:7076/api/Orders";
		}

		public async Task<IActionResult> Index()
        {
			HttpResponseMessage httpResponse = await client.GetAsync(api);
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Order> orders = JsonSerializer.Deserialize<List<Order>>(data, options);
			DisplayOrder displayOrder = new DisplayOrder()
			{
				Orders = orders,
			};
			return View(displayOrder);
        }
    }
}
