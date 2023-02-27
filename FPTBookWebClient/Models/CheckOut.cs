using BusinessObjects;

namespace FPTBookWebClient.Models
{
	public class CheckOut
	{
		public decimal Shipping { get; set; } = 0;
		public AppUser User { get; set; }
		public List<CartItem> CartItem { get; set; }
	}
}
