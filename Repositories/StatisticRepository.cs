using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class StatisticRepository : IStatisticRepository
	{
		public List<AppUser> UserBuyMost() => StatisticDAO.UserBuyMost();
		public List<Book> BookBuyMost() => StatisticDAO.BookBuyMost();
		public List<Order> TotalInMonth(int month) => StatisticDAO.TotalInMonth(month);
	}
}
