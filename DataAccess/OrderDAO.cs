using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class OrderDAO
	{
		public static List<Order> GetOrders()
		{
			var listOrders = new List<Order>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					listOrders = context.Orders.Where(x => x.IsDeleted == false).OrderByDescending(x => x.OrderDate).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return listOrders;
		}

		public static Order FindOrderById(int orderId)
		{
			Order order = new Order();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					order = context.Orders.SingleOrDefault(x => x.OrderId == orderId);
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return order;
		}

		public static int SaveOrder(Order order)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					context.Orders.Add(order);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return order.OrderId;
		}

		public static void ChangeStatus(Order order)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					context.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public static void DeleteOrder(Order order)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					var o = context.Orders.SingleOrDefault(o => o.OrderId == order.OrderId);
					//context.Genres.Remove(c);
					o.IsDeleted = true;
					context.Entry<Order>(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}
