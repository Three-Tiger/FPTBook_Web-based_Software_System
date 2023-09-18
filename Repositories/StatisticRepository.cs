using BusinessObjects;
using DataAccess;
using Repositories.Interfaces;

namespace Repositories
{
    public class StatisticRepository : IStatisticRepository
	{
		public List<AppUser> UserBuyMost() => StatisticDAO.UserBuyMost();
		public List<Book> BookBuyMost() => StatisticDAO.BookBuyMost();
		public List<Order> TotalInMonth(int month) => StatisticDAO.TotalInMonth(month);
	}
}
