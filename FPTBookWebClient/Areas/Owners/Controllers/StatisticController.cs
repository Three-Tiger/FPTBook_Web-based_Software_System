using FPTBookWebClient.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPTBookWebClient.Areas.Owners.Controllers
{
    [Authorize(Roles = "Owner")]
    [Area("Owners")]
    public class StatisticController : Controller
    {
        // GET: DataStatisticController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DataStatisticController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DataStatisticController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataStatisticController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DataStatisticController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DataStatisticController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DataStatisticController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DataStatisticController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
