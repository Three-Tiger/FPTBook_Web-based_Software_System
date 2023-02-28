using BusinessObjects;

namespace FPTBookWebClient.Models
{
	public class ShowIndexView
	{
		public List<Book> Galleries { get; set; }
		public List<Book> BestSellings { get;set; }
		public Contact Contact { get; set; }
	}
}
