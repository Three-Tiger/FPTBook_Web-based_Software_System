using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace FPTBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatisticsController : ControllerBase
	{
		private IStatisticRepository repository = new StatisticRepository();

		// GET: api/<StatisticsController>
		[HttpGet("Users")]
		public ActionResult<IEnumerable<AppUser>> UserBuyMost()
		{
			return repository.UserBuyMost();
		}

		// GET: api/<StatisticsController>
		[HttpGet("Books")]
		public ActionResult<IEnumerable<Book>> BookBuyMost()
		{
			return repository.BookBuyMost();
		}

		// GET: api/<StatisticsController>
		[HttpGet("Total")]
		public ActionResult<IEnumerable<Order>> TotalInMonth()
		{
			DateTime dateTime = DateTime.Now;
			return repository.TotalInMonth(dateTime.Month);
		}
	}
}
