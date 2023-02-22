using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FPTBookWebClient.Areas.Owners.Controllers
{
	[Authorize(Roles = "Owner")]
	[Area("Owners")]
	public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
