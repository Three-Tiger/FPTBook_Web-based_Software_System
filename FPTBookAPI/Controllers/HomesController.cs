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

		// GET: api/<AuthorsController>/Shop
		[HttpGet("Detail/{id}")]
		public ActionResult<Book> DisplayBooksDetail(int id)
		{
			return repository.DisplayBooksDetail(id);
		}

		// GET: api/<AuthorsController>/Shop/Genre
		[HttpGet("Shop/Genre")]
		public ActionResult<IEnumerable<Genre>> DisplayGenresInShop()
		{
			return repository.DisplayGenresInShop();
		}

		// GET: api/<AuthorsController>/Shop/Author
		[HttpGet("Shop/Author")]
		public ActionResult<IEnumerable<Author>> DisplayAuthorsInShop()
		{
			return repository.DisplayAuthorsInShop();
		}

		// GET: api/<AuthorsController>/Shop/Publisher
		[HttpGet("Shop/Publisher")]
		public ActionResult<IEnumerable<Publisher>> DisplayPublishersInShop()
		{
			return repository.DisplayPublishersInShop();
		}
	}
}
