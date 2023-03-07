using System.ComponentModel.DataAnnotations;

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
