using BusinessObjects;

namespace Repositories
{
	public interface IStatisticRepository
	{
		List<AppUser> UserBuyMost();
		List<Book> BookBuyMost();
		List<Order> TotalInMonth(int month);
	}
}
