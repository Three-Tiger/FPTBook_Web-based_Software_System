using BusinessObjects;
using BusinessObjects.Constraints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace FPTBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		IUserRepository repository = new UserRepository();
		//private readonly UserManager<AppUser> _userManager;
		/*public UsersController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}*/

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
