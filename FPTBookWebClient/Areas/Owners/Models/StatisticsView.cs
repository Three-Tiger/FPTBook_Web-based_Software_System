using BusinessObjects;

namespace FPTBookWebClient.Areas.Owners.Models
{
    public class StatisticsView
    {
        public List<AppUser> UsersBuyMost { get; set; }
        public List<Book> BooksBuyMost { get; set; }
        public List<Order> OrdersTotalInMonth { get; set; }
    }
}
