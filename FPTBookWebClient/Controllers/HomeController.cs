﻿using BusinessObjects;
using FPTBookWebClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FPTBookWebClient.Controllers
{
	public class HomeController : Controller
	{
		private readonly HttpClient client = null;
		private string api;
		private string apiBook;
		private string apiFeedback;

		public HomeController()
		{
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			this.api = "https://localhost:7076/api/Homes";
			this.apiBook = "https://localhost:7076/api/Books";
			this.apiFeedback = "https://localhost:7076/api/Feedbacks";
		}

		public async Task<IActionResult> Index()
		{
			HttpResponseMessage httpResponseGallary = await client.GetAsync(api + "/Galleries");
			string dataGallary = await httpResponseGallary.Content.ReadAsStringAsync();
			var optionsGallary = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Book> gallaries = JsonSerializer.Deserialize<List<Book>>(dataGallary, optionsGallary);

			HttpResponseMessage httpResponseBest = await client.GetAsync(api + "/BestSellings");
			string dataBest = await httpResponseBest.Content.ReadAsStringAsync();
			var optionsBest = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Book> bestSellings = JsonSerializer.Deserialize<List<Book>>(dataBest, optionsBest);

			ShowIndexView showIndex = new ShowIndexView()
			{
				Galleries = gallaries,
				BestSellings = bestSellings
			};

			return View(showIndex);
		}

		public async Task<IActionResult> Shop(int pg = 1)
		{
			HttpResponseMessage httpResponse = await client.GetAsync(api + "/Shop/Genres");
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Genre> genres = JsonSerializer.Deserialize<List<Genre>>(data, options);
			ViewData["Genre"] = genres;

			HttpResponseMessage httpResponse1 = await client.GetAsync(api + "/Shop/Authors");
			string data1 = await httpResponse1.Content.ReadAsStringAsync();
			var options1 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Author> authors = JsonSerializer.Deserialize<List<Author>>(data1, options1);
			ViewData["Author"] = authors;

			HttpResponseMessage httpResponse3 = await client.GetAsync(api + "/Shop");
			string data3 = await httpResponse3.Content.ReadAsStringAsync();
			var options3 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Book> books = JsonSerializer.Deserialize<List<Book>>(data3, options3);

			const int pageSize = 12;
			if (pg < 1)
			{
				pg = 1;
			}
			int recsCount = books.Count;
			var paper = new Pager(recsCount, pg, pageSize);
			int recSkip = (pg - 1) * pageSize;
			var dataBooks = books.Skip(recSkip).Take(paper.PageSize).ToList();

			this.ViewBag.Pager = paper;

			return View(dataBooks);
		}

		public async Task<IActionResult> Detail(int id)
		{
			HttpResponseMessage responseBook = await client.GetAsync(apiBook + "/" + id);
			HttpResponseMessage responseFeedback = await client.GetAsync(apiFeedback + "/Checked/" + id);
			if (responseBook.IsSuccessStatusCode && responseFeedback.IsSuccessStatusCode)
			{
				var dataBook = responseBook.Content.ReadAsStringAsync().Result;
				var optionsBook = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				Book book = JsonSerializer.Deserialize<Book>(dataBook, optionsBook);

				var dataFeedback = responseFeedback.Content.ReadAsStringAsync().Result;
				var optionsFeedback = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
				List<Feedback> feedbacks = JsonSerializer.Deserialize<List<Feedback>>(dataFeedback, optionsFeedback);

				BookDetailView bookDetailView = new BookDetailView()
				{
					Book = book,
					Feedbacks = feedbacks
				};
				return View(bookDetailView);
			}
			return NotFound();
		}

		public IActionResult About()
		{
			return View();
		}

		[Route("/Home/Shop/Genre/{genreId:int}", Name = "displaybookbygenre")]
		public async Task<IActionResult> Genre(int genreId)
		{
			HttpResponseMessage httpResponse = await client.GetAsync(api + "/Shop/Genres");
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Genre> genres = JsonSerializer.Deserialize<List<Genre>>(data, options);
			ViewData["Genre"] = genres;

			HttpResponseMessage httpResponse1 = await client.GetAsync(api + "/Shop/Authors");
			string data1 = await httpResponse1.Content.ReadAsStringAsync();
			var options1 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Author> authors = JsonSerializer.Deserialize<List<Author>>(data1, options1);
			ViewData["Author"] = authors;

			HttpResponseMessage httpResponse3 = await client.GetAsync(api + "/Shop/Genre/" + genreId);
			string data3 = await httpResponse3.Content.ReadAsStringAsync();
			var options3 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Book> books = JsonSerializer.Deserialize<List<Book>>(data3, options3);

			return View("Shop", books);
		}

		[Route("/Home/Shop/Author/{authorId:int}", Name = "displaybookbyauthor")]
		public async Task<IActionResult> Author(int authorId)
		{
			HttpResponseMessage httpResponse = await client.GetAsync(api + "/Shop/Genres");
			string data = await httpResponse.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Genre> genres = JsonSerializer.Deserialize<List<Genre>>(data, options);
			ViewData["Genre"] = genres;

			HttpResponseMessage httpResponse1 = await client.GetAsync(api + "/Shop/Authors");
			string data1 = await httpResponse1.Content.ReadAsStringAsync();
			var options1 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Author> authors = JsonSerializer.Deserialize<List<Author>>(data1, options1);
			ViewData["Author"] = authors;

			HttpResponseMessage httpResponse3 = await client.GetAsync(api + "/Shop/Author/" + authorId);
			string data3 = await httpResponse3.Content.ReadAsStringAsync();
			var options3 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			List<Book> books = JsonSerializer.Deserialize<List<Book>>(data3, options3);

			return View("Shop", books);
		}
	}
}