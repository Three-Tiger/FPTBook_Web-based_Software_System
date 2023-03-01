using BusinessObjects;

namespace FPTBookWebClient.Models
{
	public class BookDetailView
	{
		public Book Book { get; set; }
		public List<Feedback> Feedbacks { get; set; }
	}
}
