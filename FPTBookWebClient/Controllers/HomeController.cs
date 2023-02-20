using FPTBookWebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FPTBookWebClient.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Shop()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}
	}
}