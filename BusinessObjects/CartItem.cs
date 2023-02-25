using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public class CartItem
	{
		[Key]
		public int Id { get; set; }
		public int Quantity { set; get; }
		public Book Book { set; get; }
	}
}
