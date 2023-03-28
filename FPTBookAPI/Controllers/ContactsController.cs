using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace FPTBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private IContactRepository repository = new ContactRepository();

		// GET: api/<ContactsController>
		[HttpGet]
		public ActionResult<IEnumerable<Contact>> Get()
		{
			return repository.GetContacts();
		}

		// GET api/<ContactsController>/5
		[HttpGet("{id}")]
		public ActionResult<Contact> Get(int id)
		{
			return repository.GetContactById(id);
		}

		// POST api/<ContactsController>
		[HttpPost]
		public IActionResult Post([FromForm] Contact obj)
		{
			repository.SaveContact(obj);
			return NoContent();
		}

		// PUT api/<ContactsController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Contact obj)
		{
			var contact = repository.GetContactById(id);
			if (contact == null)
			{
				return NotFound();
			}
			obj.ContactDate = contact.ContactDate;
			obj.ReplyDate = DateTime.Now;
			repository.UpdateContact(obj);
			return NoContent();
		}

		// DELETE api/<ContactsController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var contact = repository.GetContactById(id);
			if (contact == null)
			{
				return NotFound();
			}
			repository.DeleteContact(contact);
			return NoContent();
		}
	}
}
