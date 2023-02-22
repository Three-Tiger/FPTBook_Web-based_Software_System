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
	public class BookController : Controller
    {
		private readonly HttpClient client = null;
		private string api;
		public BookController()
		{
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "https://localhost:7076/api/Books";
		}

		public async Task<IActionResult> Index()
		{
			HttpResponseMessage httpResponse = await client.GetAsync(api);
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Book> books = JsonSerializer.Deserialize<List<Book>>(data, options);
			return View(books);
		}

		public async Task<IActionResult> Create()
		{
			HttpResponseMessage httpResponse = await client.GetAsync("https://localhost:7076/api/Genres/Approvel");
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Genre> genres = JsonSerializer.Deserialize<List<Genre>>(data, options);
			ViewData["GenreId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(genres, "GenreId", "GenreName");

			HttpResponseMessage httpResponse1 = await client.GetAsync("https://localhost:7076/api/Authors");
			string data1 = await httpResponse1.Content.ReadAsStringAsync();
			var options1 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Author> authors = JsonSerializer.Deserialize<List<Author>>(data1, options1);
			ViewData["AuthorId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(authors, "AuthorId", "AuthorName");

			HttpResponseMessage httpResponse2 = await client.GetAsync("https://localhost:7076/api/Publishers");
			string data2 = await httpResponse2.Content.ReadAsStringAsync();
			var options2 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Publisher> publishers = JsonSerializer.Deserialize<List<Publisher>>(data2, options2);
			ViewData["PublisherId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(publishers, "PublisherId", "PublisherName");

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Book book)
		{
			if (ModelState.IsValid)
			{
				string data3 = JsonSerializer.Serialize(book);
				var content = new StringContent(data3, System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage response = await client.PostAsync(this.api, content);
				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index");
				}
			}

			HttpResponseMessage httpResponse = await client.GetAsync("https://localhost:7076/api/Genres/Approvel");
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Genre> genres = JsonSerializer.Deserialize<List<Genre>>(data, options);
			ViewData["GenreId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(genres, "GenreId", "GenreName");

			HttpResponseMessage httpResponse1 = await client.GetAsync("https://localhost:7076/api/Authors");
			string data1 = await httpResponse1.Content.ReadAsStringAsync();
			var options1 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Author> authors = JsonSerializer.Deserialize<List<Author>>(data1, options1);
			ViewData["AuthorId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(authors, "AuthorId", "AuthorName");

			HttpResponseMessage httpResponse2 = await client.GetAsync("https://localhost:7076/api/Publishers");
			string data2 = await httpResponse2.Content.ReadAsStringAsync();
			var options2 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Publisher> publishers = JsonSerializer.Deserialize<List<Publisher>>(data2, options2);
			ViewData["PublisherId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(publishers, "PublisherId", "PublisherName");

			return View(book);	
		}
		public async Task<IActionResult> Update(int id)
		{
			HttpResponseMessage reponse = await client.GetAsync(api + "/" + id);
			if (reponse.IsSuccessStatusCode)
			{
				var data3 = reponse.Content.ReadAsStringAsync().Result;
				var options3 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				var obj = JsonSerializer.Deserialize<Book>(data3, options3);

				HttpResponseMessage httpResponse = await client.GetAsync("https://localhost:7076/api/Genres/Approvel");
				string data = await httpResponse.Content.ReadAsStringAsync();
				var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				List<Genre> genres = JsonSerializer.Deserialize<List<Genre>>(data, options);
				ViewData["GenreId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(genres, "GenreId", "GenreName");

				HttpResponseMessage httpResponse1 = await client.GetAsync("https://localhost:7076/api/Authors");
				string data1 = await httpResponse1.Content.ReadAsStringAsync();
				var options1 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				List<Author> authors = JsonSerializer.Deserialize<List<Author>>(data1, options1);
				ViewData["AuthorId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(authors, "AuthorId", "AuthorName");

				HttpResponseMessage httpResponse2 = await client.GetAsync("https://localhost:7076/api/Publishers");
				string data2 = await httpResponse2.Content.ReadAsStringAsync();
				var options2 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				List<Publisher> publishers = JsonSerializer.Deserialize<List<Publisher>>(data2, options2);
				ViewData["PublisherId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(publishers, "PublisherId", "PublisherName");

				return View(obj);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> Update(int id, Book book)
		{
			book.BookId = id;
			string data = JsonSerializer.Serialize<Book>(book);
			var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
			HttpResponseMessage response = await client.PutAsync(api + "/" + id, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View(book);
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
