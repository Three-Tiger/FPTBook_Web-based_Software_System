﻿using BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FPTBookWebClient.Areas.Owners.Controllers
{
	[Authorize(Roles = "Owner")]
	[Area("Owners")]
	public class BookController : Controller
	{
		private readonly IConfiguration _configuration;
		private readonly HttpClient client = null;
		private string api;
		private string apiGenre;
		private string apiAuthor;
		private string apiPublisher;
		public BookController(IConfiguration configuration)
		{
			_configuration = configuration;
			client = new HttpClient();
			client.BaseAddress = new Uri(_configuration["BaseAddress"]);
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "/api/Books";
			this.apiGenre = "/api/Genres/Approvel";
			this.apiAuthor = "/api/Authors";
			this.apiPublisher = "/api/Publishers";
		}

		public async Task<IActionResult> Index()
		{
            ViewData["api"] = _configuration["BaseAddress"];

            HttpResponseMessage httpResponse = await client.GetAsync(api);
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Book> books = JsonSerializer.Deserialize<List<Book>>(data, options);
			return View(books);
		}

		public async Task<IActionResult> Create()
		{
			ViewData["api"] = _configuration["BaseAddress"];

			HttpResponseMessage httpResponse = await client.GetAsync(apiGenre);
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Genre> genres = JsonSerializer.Deserialize<List<Genre>>(data, options);
			ViewData["GenreId"] = new SelectList(genres, "GenreId", "GenreName");

			HttpResponseMessage httpResponse1 = await client.GetAsync(apiAuthor);
			string data1 = await httpResponse1.Content.ReadAsStringAsync();
			var options1 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Author> authors = JsonSerializer.Deserialize<List<Author>>(data1, options1);
			ViewData["AuthorId"] = new SelectList(authors, "AuthorId", "AuthorName");

			HttpResponseMessage httpResponse2 = await client.GetAsync(apiPublisher);
			string data2 = await httpResponse2.Content.ReadAsStringAsync();
			var options2 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Publisher> publishers = JsonSerializer.Deserialize<List<Publisher>>(data2, options2);
			ViewData["PublisherId"] = new SelectList(publishers, "PublisherId", "PublisherName");

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

			HttpResponseMessage httpResponse = await client.GetAsync(apiGenre);
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Genre> genres = JsonSerializer.Deserialize<List<Genre>>(data, options);
			ViewData["GenreId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(genres, "GenreId", "GenreName");

			HttpResponseMessage httpResponse1 = await client.GetAsync(apiAuthor);
			string data1 = await httpResponse1.Content.ReadAsStringAsync();
			var options1 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Author> authors = JsonSerializer.Deserialize<List<Author>>(data1, options1);
			ViewData["AuthorId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(authors, "AuthorId", "AuthorName");

			HttpResponseMessage httpResponse2 = await client.GetAsync(apiPublisher);
			string data2 = await httpResponse2.Content.ReadAsStringAsync();
			var options2 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Publisher> publishers = JsonSerializer.Deserialize<List<Publisher>>(data2, options2);
			ViewData["PublisherId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(publishers, "PublisherId", "PublisherName");

			return View(book);
		}

		public async Task<IActionResult> Update(int id)
		{
			try
			{
				HttpResponseMessage reponse = await client.GetAsync(api + "/" + id);
				if (reponse.IsSuccessStatusCode)
				{
					ViewData["api"] = _configuration["BaseAddress"];

					var data3 = reponse.Content.ReadAsStringAsync().Result;
					var options3 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
					var obj = JsonSerializer.Deserialize<Book>(data3, options3);

					HttpResponseMessage httpResponse = await client.GetAsync(apiGenre);
					string data = await httpResponse.Content.ReadAsStringAsync();
					var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
					List<Genre> genres = JsonSerializer.Deserialize<List<Genre>>(data, options);
					ViewData["GenreId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(genres, "GenreId", "GenreName");

					HttpResponseMessage httpResponse1 = await client.GetAsync(apiAuthor);
					string data1 = await httpResponse1.Content.ReadAsStringAsync();
					var options1 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
					List<Author> authors = JsonSerializer.Deserialize<List<Author>>(data1, options1);
					ViewData["AuthorId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(authors, "AuthorId", "AuthorName");

					HttpResponseMessage httpResponse2 = await client.GetAsync(apiPublisher);
					string data2 = await httpResponse2.Content.ReadAsStringAsync();
					var options2 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
					List<Publisher> publishers = JsonSerializer.Deserialize<List<Publisher>>(data2, options2);
					ViewData["PublisherId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(publishers, "PublisherId", "PublisherName");

					return View(obj);
				}
				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				return RedirectToAction("Index");
			}
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
