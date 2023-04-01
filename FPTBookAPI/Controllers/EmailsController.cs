using BusinessObjects;
using EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPTBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmailsController : ControllerBase
	{
		private readonly IEmailSender _emailSender;

		public EmailsController(IEmailSender emailSender)
		{
			_emailSender = emailSender;
		}

		// POST: api/<EmailsController>
		[HttpPost]
		public IActionResult SendMail([FromBody] Message message)
		{
			_emailSender.SendEmail(message);
			return NoContent();
		}
	}
}
