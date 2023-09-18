using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Interfaces;

namespace FPTBookAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class HomesController : Controller
	{
		private IHomeRepository repository = new HomeRepository();

		// GET: api/<HomesController>/Gallery
		[HttpGet("Galleries")]
		public ActionResult<IEnumerable<Book>> Gallery()
		{
			return repository.Gallery();
		}

		// GET: api/<HomesController>/BestSelling
		[HttpGet("BestSellings")]
		public ActionResult<IEnumerable<Book>> BestSelling()
		{
			return repository.BestSelling();
		}

		// GET: api/<HomesController>/Shop
		[HttpGet("Shop")]
		public ActionResult<IEnumerable<Book>> DisplayBooksInShop()
		{
			return repository.DisplayBooksInShop();
		}

		// GET: api/<HomesController>/Shop
		[HttpGet("Shop/{searchValue}")]
		public ActionResult<IEnumerable<Book>> Search(string searchValue)
		{
			return repository.Search(searchValue);
		}

		// GET: api/<HomesController>/Detail/5
		[HttpGet("Detail/{id}")]
		public ActionResult<Book> DisplayBooksDetail(int id)
		{
			return repository.DisplayBooksDetail(id);
		}

		// GET: api/<HomesController>/Shop/Genres
		[HttpGet("Shop/Genres")]
		public ActionResult<IEnumerable<Genre>> DisplayGenresInShop()
		{
			return repository.DisplayGenresInShop();
		}

		// GET: api/<HomesController>/Shop/Authors
		[HttpGet("Shop/Authors")]
		public ActionResult<IEnumerable<Author>> DisplayAuthorsInShop()
		{
			return repository.DisplayAuthorsInShop();
		}

		// GET: api/<HomesController>/Shop/Publishers
		[HttpGet("Shop/Publishers")]
		public ActionResult<IEnumerable<Publisher>> DisplayPublishersInShop()
		{
			return repository.DisplayPublishersInShop();
		}

		// GET: api/<HomesController>/Shop/5
		[HttpGet("Shop/Genre/{genreId}")]
		public ActionResult<IEnumerable<Book>> DisplayBooksInShopByGenre(int genreId)
		{
			return repository.DisplayBooksInShopByGenre(genreId);
		}

		// GET: api/<HomesController>/Shop/5
		[HttpGet("Shop/Author/{authorId}")]
		public ActionResult<IEnumerable<Book>> DisplayBooksInShopByAuthor(int authorId)
		{
			return repository.DisplayBooksInShopByAuthor(authorId);
		}
	}
}
