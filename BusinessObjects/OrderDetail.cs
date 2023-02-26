using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public class OrderDetail
	{
		[Key]
		[Column(Order = 1)]
		public int OrderId { get; set; }
		[Key]
		[Column(Order = 2)]
		public int BookId { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPrice { get; set; }

		[ForeignKey("OrderId")]
		public virtual Order? Order { get; set; }
		[ForeignKey("BookId")]
		public virtual Book? Book { get; set; }
	}
}
