using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace FPTBookAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private IOrderRepository repository = new OrderRepository();

		// GET: api/<OrdersController>
		[HttpGet]
		public ActionResult<IEnumerable<Order>> Get()
		{
			return repository.GetOrders();
		}

		// POST api/<OrdersController>
		[HttpPost]
		public int Post([FromBody] Order obj)
		{
			return repository.SaveOrder(obj);
		}
	}
}
