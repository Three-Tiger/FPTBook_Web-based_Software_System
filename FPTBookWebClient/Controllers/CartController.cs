using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;

namespace FPTBookWebClient.Controllers
{
	[Authorize]
	public class CartController : Controller
	{
		private readonly HttpClient client = null;
		private string api;

		// Cart's json string key
		public const string CARTKEY = "cart";

		public CartController()
		{
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "https://localhost:7076/api/Books";
		}

		public IActionResult Index()
		{
			return View(GetCartItems());
		}

		// Get cart from Session (danh sách CartItem)
		List<CartItem> GetCartItems()
		{

			var session = HttpContext.Session;
			string jsoncart = session.GetString(CARTKEY);
			if (jsoncart != null)
			{
				return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
			}
			return new List<CartItem>();
		}

		// Save Cart (List of CartItem) into session
		void SaveCartSession(List<CartItem> ls)
		{
			var session = HttpContext.Session;
			string jsoncart = JsonConvert.SerializeObject(ls);
			session.SetString(CARTKEY, jsoncart);
		}

		// Remove cart from session
		void ClearCart()
		{
			var session = HttpContext.Session;
			session.Remove(CARTKEY);
		}

		[HttpPost("{bookId}")]
		public async Task<IActionResult> AddToCart(int bookId, int quantity)
		{
			HttpResponseMessage reponse = await client.GetAsync(api + "/" + bookId);
			if (reponse.IsSuccessStatusCode)
			{
				var data = reponse.Content.ReadAsStringAsync().Result;
				var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				var book = System.Text.Json.JsonSerializer.Deserialize<Book>(data, options);

				// Handling put into Cart
				var cart = GetCartItems();
				var cartitem = cart.Find(b => b.Book.BookId == bookId);

				if (cartitem != null)
				{
					// Already exist, increase by quantity
					cartitem.Quantity += quantity;
				}
				else
				{
					//  Add new
					cart.Add(new CartItem() { Quantity = quantity, Book = book });
				}

				// Save cart to Session
				SaveCartSession(cart);
				return RedirectToAction("Index");
			}
			return NotFound();
		}

		// Update quantity
		[HttpPut]
		public IActionResult UpdateQuantity(int bookId, int quantity)
		{
			// Cập nhật Cart thay đổi số lượng quantity ...
			var cart = GetCartItems();
			var cartitem = cart.Find(b => b.Book.BookId == bookId);
			if (cartitem != null)
			{
				cartitem.Quantity = quantity;
			}
			SaveCartSession(cart);
			return Ok();
		}

		[HttpDelete]
		/// remove item in cart
		public IActionResult RemoveCart(int id)
		{
			var cart = GetCartItems();
			var cartitem = cart.Find(p => p.Book.BookId == id);
			if (cartitem != null)
			{
				cart.Remove(cartitem);
			}
			SaveCartSession(cart);
			//return Ok();
			return RedirectToAction("Index");
		}
	}
}
