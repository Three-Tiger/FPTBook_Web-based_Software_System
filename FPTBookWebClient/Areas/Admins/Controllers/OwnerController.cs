using Microsoft.AspNetCore.Mvc;

namespace FPTBookWebClient.Areas.Admins.Controllers
{
    public class OwnerController : Controller
    {
        [Area("Admins")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
