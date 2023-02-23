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

		// GET: api/<AuthorsController>/Shop/Genre
		[HttpGet("Shop/Genres")]
		public ActionResult<IEnumerable<Genre>> DisplayGenresInShop()
		{
			return repository.DisplayGenresInShop();
		}

		// GET: api/<AuthorsController>/Shop/Author
		[HttpGet("Shop/Authors")]
		public ActionResult<IEnumerable<Author>> DisplayAuthorsInShop()
		{
			return repository.DisplayAuthorsInShop();
		}

		// GET: api/<AuthorsController>/Shop/Publisher
		[HttpGet("Shop/Publishers")]
		public ActionResult<IEnumerable<Publisher>> DisplayPublishersInShop()
		{
			return repository.DisplayPublishersInShop();
		}
	}
}
