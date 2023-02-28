using BusinessObjects;
using FPTBookWebClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Controllers
{
	[Authorize]
	public class CartController : Controller
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<AppUser> _userManager;
		private readonly HttpClient client = null;
		private string api;

		// Cart's json string key
		public const string CARTKEY = "cart";

		public CartController(UserManager<AppUser> userManager, ApplicationDbContext db)
		{
			_userManager = userManager;
			_db = db;
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

		[HttpPost]
		public async Task<IActionResult> CheckOut(decimal shipping)
		{
			var userId = _userManager.GetUserId(User);
			string apiGetUser = "https://localhost:7076/api/Users/Account/" + userId;
			HttpResponseMessage reponse = await client.GetAsync(apiGetUser);
			if (reponse.IsSuccessStatusCode)
			{
				CheckOutView checkOut = new CheckOutView();
				var data = reponse.Content.ReadAsStringAsync().Result;
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				var obj = System.Text.Json.JsonSerializer.Deserialize<AppUser>(data, options);
				checkOut.Shipping = shipping;
				checkOut.User = obj;
				checkOut.CartItem = GetCartItems();
				return View(checkOut);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> Payment(CheckOutView checkOut)
		{
			var userId = _userManager.GetUserId(User);
			// Add to Order table
			Order order = new Order()
			{
				DeliveryLocal = checkOut.User.Address,
				OrderName = checkOut.User.FirstName + " " + checkOut.User.LastName,
				OrderPhone = checkOut.User.PhoneNumber,
				ShippingFee = checkOut.Shipping,
				UserId = userId,
			};
			string dataOrder = System.Text.Json.JsonSerializer.Serialize(order);
			var contentOrder = new StringContent(dataOrder, System.Text.Encoding.UTF8, "application/json");
			HttpResponseMessage responseOrder = await client.PostAsync("https://localhost:7076/api/Orders", contentOrder);
			if (responseOrder.IsSuccessStatusCode)
			{
				// Retrieve order id inserted
				var data = responseOrder.Content.ReadAsStringAsync().Result;
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				var obj = System.Text.Json.JsonSerializer.Deserialize<int>(data, options);
				int orderId = obj;
				foreach (var cartItem in GetCartItems())
				{
					// Add to order detail table
					OrderDetail orderDetail = new OrderDetail();
					orderDetail.OrderId = orderId;
					orderDetail.BookId = cartItem.Book.BookId;
					orderDetail.Quantity = cartItem.Quantity;
					decimal salePrice = cartItem.Book.BookPrice - (cartItem.Book.BookPrice * ((decimal)cartItem.Book.SalePercent / 100m));
					orderDetail.TotalPrice = cartItem.Quantity * salePrice;

					string dataOrderDetail = System.Text.Json.JsonSerializer.Serialize(orderDetail);
					var contentOrderDetail = new StringContent(dataOrderDetail, System.Text.Encoding.UTF8, "application/json");
					HttpResponseMessage responseOrderDetail = await client.PostAsync("https://localhost:7076/api/OrderDetails", contentOrderDetail);

					if (responseOrderDetail.IsSuccessStatusCode)
					{
						// Minus stock
						cartItem.Book.BookStock -= cartItem.Quantity;
						_db.Books.Update(cartItem.Book);
						_db.SaveChanges();
					}
				}
				ClearCart();
				//return RedirectToAction("Index");
				return Ok();
			}
			return NotFound();
		}
	}
}
