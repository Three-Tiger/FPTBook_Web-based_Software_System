using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FPTBookWebClient.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
