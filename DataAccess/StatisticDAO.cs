using BusinessObjects;
using BusinessObjects.Constraints;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
	public class StatisticDAO
	{
		public static List<AppUser> UserBuyMost()
		{
			var lstUsers = new List<AppUser>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var lstUsersId = context.Orders.Where(u => u.IsDeleted == false)
								.GroupBy(x => x.UserId)
								.OrderByDescending(g => g.Count())
								.Take(5)
								.Select(x => x.Key)
								.ToList();

					foreach (var item in lstUsersId)
					{
						AppUser obj = context.Users.Find(item);
						lstUsers.Add(obj);
					}
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return lstUsers;
		}

		public static List<Book> BookBuyMost()
		{
			var lstBooks = new List<Book>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var lstBookId = context.OrderDetails.Where(u => u.Book.IsDeleted == false)
								.GroupBy(x => x.BookId)
								.OrderByDescending(g => g.Count())
								.Take(5)
								.Select(x => x.Key)
								.ToList();
					lstBooks = context.Books
						.Include(b => b.Genre)
						.Include(b => b.Author)
						.Include(b => b.Publisher)
						.Where(b => b.IsDeleted == false && lstBookId.Contains(b.BookId))
						.Select(b => new Book
						{
							BookId = b.BookId,
							BookTitle = b.BookTitle,
							BookPrice = b.BookPrice,
							BookOriginalPrice = b.BookOriginalPrice,
							SalePercent = b.SalePercent,
							BookStock = b.BookStock,
							BookImage = b.BookImage,
							Genre = b.Genre,
							Author = b.Author,
							Publisher = b.Publisher,
						}).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return lstBooks;
		}

		public static List<Order> TotalInMonth(int month)
		{
			var lstOrders = new List<Order>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var lstOrdersId = context.OrderDetails
						.Where(c => c.Order.OrderDate.Month == month && c.Order.OrderStatus != OrderStatus.Canceled && c.Order.OrderStatus == OrderStatus.Received)
						.GroupBy(od => od.OrderId)
						.OrderByDescending(d => d.Sum(f => f.TotalPrice + f.Order.ShippingFee))
						.Select(b => b.Key).ToList();
					lstOrders = context.Orders
						.Include(o => o.OrderDetails)
						.Where(o => o.IsDeleted == false && lstOrdersId.Contains(o.OrderId))
						.ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return lstOrders;
		}
	}
}
