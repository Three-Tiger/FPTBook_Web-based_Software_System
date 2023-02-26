using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace FPTBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomesController : Controller
	{
		private IHomeRepository repository = new HomeRepository();

		// GET: api/<AuthorsController>/Shop
		[HttpGet("Shop")]
		public ActionResult<IEnumerable<Book>> DisplayBooksInShop()
		{
			return repository.DisplayBooksInShop();
		}

		// GET: api/<AuthorsController>/Detail/5
		[HttpGet("Detail/{id}")]
		public ActionResult<Book> DisplayBooksDetail(int id)
		{
			return repository.DisplayBooksDetail(id);
		}

		// GET: api/<AuthorsController>/Shop/Genres
		[HttpGet("Shop/Genres")]
		public ActionResult<IEnumerable<Genre>> DisplayGenresInShop()
		{
			return repository.DisplayGenresInShop();
		}

		// GET: api/<AuthorsController>/Shop/Authors
		[HttpGet("Shop/Authors")]
		public ActionResult<IEnumerable<Author>> DisplayAuthorsInShop()
		{
			return repository.DisplayAuthorsInShop();
		}

		// GET: api/<AuthorsController>/Shop/Publishers
		[HttpGet("Shop/Publishers")]
		public ActionResult<IEnumerable<Publisher>> DisplayPublishersInShop()
		{
			return repository.DisplayPublishersInShop();
		}

		// GET: api/<AuthorsController>/Shop/5
		[HttpGet("Shop/Genre/{genreId}")]
		public ActionResult<IEnumerable<Book>> DisplayBooksInShopByGenre(int genreId)
		{
			return repository.DisplayBooksInShopByGenre(genreId);
		}

		// GET: api/<AuthorsController>/Shop/5
		[HttpGet("Shop/Author/{authorId}")]
		public ActionResult<IEnumerable<Book>> DisplayBooksInShopByAuthor(int authorId)
		{
			return repository.DisplayBooksInShopByAuthor(authorId);
		}
	}
}
