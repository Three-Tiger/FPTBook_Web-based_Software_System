using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class OrderDetailRepository : IOrderDetailRepository
	{
		public List<OrderDetail> FindOrderDetailById(int orderId) => OrderDetailDAO.FindOrderDetailById(orderId);
		public void SaveOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.SaveOrderDetail(orderDetail);
	}
}
