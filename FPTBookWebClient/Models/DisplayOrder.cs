using BusinessObjects;
using BusinessObjects.Constraints;

namespace FPTBookWebClient.Models
{
	public class DisplayOrder
	{
		public List<Order> Orders { get; set; }
		public List<OrderStatus> OrderStatus { get; set; } = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().ToList();
	}
}
