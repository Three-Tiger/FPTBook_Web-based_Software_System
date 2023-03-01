using BusinessObjects;
using BusinessObjects.Constraints;
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

		// GET api/<OrdersController>/User/8461a3e4-1021-44b2-ac47-e19df95c8465
		[HttpGet("User/{userId}")]
		public ActionResult<IEnumerable<Order>> GetOrderUsers(string userId)
		{
			return repository.FindOrderByUserId(userId);
		}

		// GET api/<OrdersController>/5
		[HttpGet("{id}")]
		public ActionResult<Order> Get(int id)
		{
			return repository.FindOrderById(id);
		}

		// POST api/<OrdersController>
		[HttpPost]
		public int Post([FromBody] Order obj)
		{
			return repository.SaveOrder(obj);
		}

		// PUT api/<OrdersController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromForm] Order obj)
		{
			var order = repository.FindOrderById(id);
			if (order == null)
			{
				return NotFound();
			}
			obj.DeliveryDate = DateTime.Now;
			repository.ChangeStatus(obj);
			return NoContent();
		}
	}
}
