using BusinessObjects;

namespace FPTBookWebClient.Models
{
	public class CheckOut
	{
		public decimal Shipping { get; set; }
		public AppUser User { get; set; }
		public List<CartItem> CartItem { get; set; }
	}
}
