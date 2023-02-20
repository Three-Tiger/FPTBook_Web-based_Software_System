using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime DeliveryDate { get; set; }
		public string DeliveryLocal { get; set; }
		public string OrderName { get; set; }
		public string OrderPhone { get; set; }
		public string OrderStatus { get; set; }
		public bool IsDeleted { get; set; }
		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual AppUser User { get; set; }
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
