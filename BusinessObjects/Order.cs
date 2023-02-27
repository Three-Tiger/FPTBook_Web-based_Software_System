using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Constraints;

namespace BusinessObjects
{
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.Now;
		public DateTime DeliveryDate { get; set; } = DateTime.Now;
		public string DeliveryLocal { get; set; }
		public string OrderName { get; set; }
		public string OrderPhone { get; set; }
		public OrderStatus OrderStatus { get; set; } = OrderStatus.Wait;
		public decimal ShippingFee { get; set; }
		public bool IsDeleted { get; set; } = false;
		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual AppUser? User { get; set; }
		public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
	}
}
