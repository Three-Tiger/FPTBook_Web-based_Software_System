using BusinessObjects;
using FPTBookWebClient.Areas.Owners.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Areas.Owners.Controllers
{
    [Authorize(Roles = "Owner")]
    [Area("Owners")]
    public class StatisticController : Controller
    {
		private readonly IConfiguration _configuration;
		private readonly HttpClient client = null;
		private string api;
		public StatisticController(IConfiguration configuration)
		{
			_configuration = configuration;
			client = new HttpClient();
			client.BaseAddress = new Uri(_configuration["BaseAddress"]);
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "/api/Statistics";
		}

		// GET: DataStatisticController
		public async Task<IActionResult> Index()
        {
			ViewData["api"] = _configuration["BaseAddress"];

			HttpResponseMessage httpResponseUser = await client.GetAsync(api + "/Users");
			string dataUser = await httpResponseUser.Content.ReadAsStringAsync();
			var optionsUser = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<AppUser> users = JsonSerializer.Deserialize<List<AppUser>>(dataUser, optionsUser);

			HttpResponseMessage httpResponseBook = await client.GetAsync(api + "/Books");
			string dataBook = await httpResponseBook.Content.ReadAsStringAsync();
			var optionsBook = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Book> books = JsonSerializer.Deserialize<List<Book>>(dataBook, optionsBook);

			HttpResponseMessage httpResponseTotal = await client.GetAsync(api + "/Total");
			string dataTotal = await httpResponseTotal.Content.ReadAsStringAsync();
			var optionsTotal = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Order> orders = JsonSerializer.Deserialize<List<Order>>(dataTotal, optionsTotal);

			StatisticsView statisticsView = new StatisticsView()
			{
				UsersBuyMost = users,
				BooksBuyMost = books,
				OrdersTotalInMonth = orders
			};

			return View(statisticsView);
        }
    }
}
