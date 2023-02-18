using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FPTBookWebClient.Areas.Owners.Controllers
{
    [Authorize(Roles = "Owner")]
    [Area("Owners")]
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
