using Microsoft.AspNetCore.Mvc;

namespace FPTBookWebClient.Areas.Owners.Controllers
{
    [Area("Owners")]
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
