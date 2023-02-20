using BusinessObjects;
using FPTBookAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FPTBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private IBookRepository repository = new BookRepository();
		private readonly IBookFileService _fileService;

		public BooksController(IBookFileService fileService)
		{
			_fileService = fileService;
		}

		// GET: api/<BooksController>
		[HttpGet]
		public ActionResult<IEnumerable<Book>> Get()
		{
			return repository.GetBooks();
		}

		// GET api/<BooksController>/5
		[HttpGet("{id}")]
		public ActionResult<Book> Get(int id)
		{
			return repository.GetBookById(id);
		}

		// POST api/<BooksController>
		[HttpPost]
		public IActionResult Post([FromForm] Book obj)
		{
			var result = _fileService.SaveBookImage(obj.ImageFile);
			obj.BookImage = _fileService.GetImageByBook(result.Item2);
			repository.SaveBook(obj);
			return NoContent();
		}

		// PUT api/<BooksController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromForm] Book obj)
		{
			var book = repository.GetBookById(id);
			if (book == null)
			{
				return NotFound();
			}
			if (obj.ImageFile != null)
			{
				var result = _fileService.SaveBookImage(obj.ImageFile);
				if (result.Item1 == 1)
				{
					var oldImage = book.BookImage;
					obj.BookImage = _fileService.GetImageByBook(result.Item2);
					_fileService.DeleteBookImage(oldImage);
				}
			}
			else
			{
				obj.BookImage = book.BookImage;
			}
			repository.UpdateBook(obj);
			return NoContent();
		}

		// DELETE api/<BooksController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var book = repository.GetBookById(id);
			if (book == null)
			{
				return NotFound();
			}
			repository.DeleteBook(book);
			return NoContent();
		}
	}
}
