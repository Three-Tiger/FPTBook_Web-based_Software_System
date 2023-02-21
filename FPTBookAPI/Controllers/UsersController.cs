using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace FPTBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private IUserRepository repository = new UserRepository();

		// GET: api/<AuthorsController>/Shop
		[HttpGet("Shop")]
		public ActionResult<IEnumerable<Book>> DisplayBooksInShop()
		{
			return repository.DisplayBooksInShop();
		}

		// GET: api/<AuthorsController>/Shop/Genre
		[HttpGet("Shop/Genre")]
		public ActionResult<IEnumerable<Genre>> DisplayGenresInShop()
		{
			return repository.DisplayGenresInShop();
		}
	}
}
