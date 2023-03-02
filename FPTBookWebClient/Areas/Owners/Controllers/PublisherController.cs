using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Areas.Owners.Controllers
{
    [Authorize(Roles = "Owner")]
    [Area("Owners")]
    public class PublisherController : Controller
    {
		private readonly IConfiguration _configuration;
		private readonly HttpClient client = null;
        private string api;
        public PublisherController(IConfiguration configuration)
        {
            _configuration = configuration;
            client = new HttpClient();
			client.BaseAddress = new Uri(_configuration["BaseAddress"]);
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            this.api = "/api/Publishers";
        }
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage httpResponse = await client.GetAsync(api);
            string data = await httpResponse.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Publisher> publishers = JsonSerializer.Deserialize<List<Publisher>>(data, options);
            return View(publishers);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                string data = JsonSerializer.Serialize(publisher);
                var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(api, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(publisher);
        }
        public async Task<IActionResult> Update(int id)
        {
            HttpResponseMessage reponse = await client.GetAsync(api + "/" + id);
            if (reponse.IsSuccessStatusCode)
            {
                var data = reponse.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var obj = JsonSerializer.Deserialize<Publisher>(data, options);
                return View(obj);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Publisher publisher)
        {
            publisher.PublisherId = id;
            string data = JsonSerializer.Serialize<Publisher>(publisher);
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(api + "/" + id, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(publisher);
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage reponse = await client.DeleteAsync(api + "/" + id);
            if (reponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
