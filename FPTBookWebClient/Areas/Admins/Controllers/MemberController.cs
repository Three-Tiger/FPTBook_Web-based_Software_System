using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Areas.Admins.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admins")]

    public class MemberController : Controller
    {
        private readonly HttpClient client = null;
        private string api;
        public MemberController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.api = "https://localhost:7076/api/Users";
        }


        public async Task<IActionResult> Index()
        {
            HttpResponseMessage httpResponse = await client.GetAsync(api + "/Members");
            string data = await httpResponse.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<AppUser> appuser = JsonSerializer.Deserialize<List<AppUser>>(data, options);
            return View(appuser);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppUser appuser)
        {
            if (ModelState.IsValid)
            {
                string data = JsonSerializer.Serialize(appuser);
                var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(api, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(appuser);
        }


        public async Task<IActionResult> Edit(string id)
        {
            HttpResponseMessage reponse = await client.GetAsync(api + "/Account/" + id);
            if (reponse.IsSuccessStatusCode)
            {
                var data = reponse.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var obj = JsonSerializer.Deserialize<AppUser>(data, options);
                return View(obj);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, AppUser appUser)
        {
            appUser.Id = id;
            string data = JsonSerializer.Serialize<AppUser>(appUser);
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(api + "/Account/" + id, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(appUser);
        }
    }
}
