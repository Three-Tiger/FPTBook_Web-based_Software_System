using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace FPTBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		IUserRepository repository = new UserRepository();

		// GET: api/<UsersController>/Members
		[HttpGet("Members")]
		public ActionResult<IEnumerable<AppUser>> GetMembers()
		{
			return repository.GetMembers();
		}

		// GET: api/<UsersController>/Account/abc
		[HttpGet("Account/{id}")]
		public ActionResult<AppUser> FindAccountById(string id)
		{
			return repository.FindAccountById(id);
		}

		// GET api/<UsersController>/Owners
		[HttpGet("Owners")]
		public ActionResult<IEnumerable<AppUser>> GetOwners()
		{
			return repository.GetOwners();
		}
	}
}
