using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class OrderDetailDAO
	{
		public static List<OrderDetail> FindOrderDetailById(int orderId)
		{
			var lstOrderDetail = new List<OrderDetail>();
			try
			{
				using (var context = new ApplicationDbContext())
				{
					lstOrderDetail = context.OrderDetails.Where(x => x.OrderId == orderId).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return lstOrderDetail;
		}

		public static void SaveOrderDetail(OrderDetail orderDetail)
		{
			try
			{
				using (var context = new ApplicationDbContext())
				{
					context.OrderDetails.Add(orderDetail);
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
