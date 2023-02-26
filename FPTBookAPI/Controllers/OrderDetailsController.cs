using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace FPTBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private IOrderDetailRepository repository = new OrderDetailRepository();

		// GET api/<OrderDetailsController>/5
		[HttpGet("{orderId}")]
		public ActionResult<IEnumerable<OrderDetail>> Get(int orderId)
		{
			return repository.FindOrderDetailById(orderId);
		}

		// POST api/<OrderDetailsController>
		[HttpPost]
		public IActionResult Post([FromBody] OrderDetail obj)
		{
			repository.SaveOrderDetail(obj);
			return NoContent();
		}
	}
}
