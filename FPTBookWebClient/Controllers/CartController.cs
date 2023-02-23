using Microsoft.AspNetCore.Mvc;

namespace FPTBookWebClient.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
