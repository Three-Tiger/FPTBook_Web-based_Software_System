﻿using BusinessObjects;
using BusinessObjects.Constraints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Areas.Owners.Controllers
{
	[Authorize(Roles = "Owner")]
	[Area("Owners")]
	public class OrderDetailController : Controller
	{
		private readonly HttpClient client = null;
		private string api;
		public OrderDetailController()
		{
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "https://localhost:7076/api/OrderDetails";
		}

		public async Task<IActionResult> Index(int orderId)
		{
			HttpResponseMessage httpResponse = await client.GetAsync(api + "/" + orderId);
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<OrderDetail> orderDetails = JsonSerializer.Deserialize<List<OrderDetail>>(data, options);
			return View(orderDetails);
		}
	}
}