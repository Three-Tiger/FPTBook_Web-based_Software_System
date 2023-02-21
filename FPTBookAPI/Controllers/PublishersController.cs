using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FPTBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PublishersController : ControllerBase
	{
		private IPublisherRepository repository = new PublisherRepository();
		private IBookRepository bookRepository = new BookRepository();

		// GET: api/<PublishersController>
		[HttpGet]
		public ActionResult<IEnumerable<Publisher>> Get()
		{
			return repository.GetPublishers();
		}

		// GET api/<PublishersController>/5
		[HttpGet("{id}")]
		public ActionResult<Publisher> Get(int id)
		{
			return repository.GetPublisherById(id);
		}

		// POST api/<PublishersController>
		[HttpPost]
		public IActionResult Post([FromBody] Publisher obj)
		{
			repository.SavePublisher(obj);
			return NoContent();
		}

		// PUT api/<PublishersController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Publisher obj)
		{
			var publisher = repository.GetPublisherById(id);
			if (publisher == null)
			{
				return NotFound();
			}
			repository.UpdatePublisher(obj);
			return NoContent();
		}

		// DELETE api/<PublishersController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var publisher = repository.GetPublisherById(id);
			if (publisher == null)
			{
				return NotFound();
			}
			var books = bookRepository.GetBooks();
			foreach (var book in books)
			{
				if (book.PublisherId == publisher.PublisherId)
				{
					bookRepository.DeleteBook(book);
				}
			}
			repository.DeletePublisher(publisher);
			return NoContent();
		}
	}
}
