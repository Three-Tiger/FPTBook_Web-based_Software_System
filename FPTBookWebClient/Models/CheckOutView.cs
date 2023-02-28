using BusinessObjects;

namespace FPTBookWebClient.Models
{
	public class CheckOutView
	{
		public decimal Shipping { get; set; } = 0;
		public AppUser User { get; set; }
		public List<CartItem> CartItem { get; set; }
	}
}
