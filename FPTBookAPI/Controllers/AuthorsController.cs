using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FPTBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorsController : ControllerBase
	{
		private IAuthorRepository repository = new AuthorRepository();

		// GET: api/<AuthorsController>
		[HttpGet]
		public ActionResult<IEnumerable<Author>> Get()
		{
			return repository.GetAuthors();
		}

		// GET api/<AuthorsController>/5
		[HttpGet("{id}")]
		public ActionResult<Author> Get(int id)
		{
			return repository.GetAuthorById(id);
		}

		// POST api/<AuthorsController>
		[HttpPost]
		public IActionResult Post([FromBody] Author obj)
		{
			repository.SaveAuthor(obj);
			return NoContent();
		}

		// PUT api/<AuthorsController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Author obj)
		{
			var author = repository.GetAuthorById(id);
			if (author == null)
			{
				return NotFound();
			}
			repository.UpdateAuthor(obj);
			return NoContent();
		}

		// DELETE api/<AuthorsController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var author = repository.GetAuthorById(id);
			if (author == null)
			{
				return NotFound();
			}
			repository.DeleteAuthor(author);
			return NoContent();
		}
	}
}
