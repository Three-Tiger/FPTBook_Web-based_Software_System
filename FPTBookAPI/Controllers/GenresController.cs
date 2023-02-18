using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FPTBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenresController : ControllerBase
	{
		private IGenreRepository repository = new GenreRepository();

		// GET: api/<GenresController>
		[HttpGet]
		public ActionResult<IEnumerable<Genre>> Get()
		{
			return repository.GetGenres();
		}

		// GET api/<GenresController>/5
		[HttpGet("{id}")]
		public ActionResult<Genre> Get(int id)
		{
			return repository.GetGenreById(id);
		}

		// POST api/<GenresController>
		[HttpPost]
		public IActionResult Post([FromBody]Genre obj)
		{
			repository.SaveGenre(obj);
			return NoContent();
		}

		// PUT api/<GenresController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody]Genre obj)
		{
			var genre = repository.GetGenreById(id);
			if (genre == null)
			{
				return NotFound();
			}
			repository.UpdateGenre(obj);
			return NoContent();
		}

		// DELETE api/<GenresController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var genre = repository.GetGenreById(id);
			if (genre == null)
			{
				return NotFound();
			}
			repository.DeleteGenre(genre);
			return NoContent();
		}
	}
}
