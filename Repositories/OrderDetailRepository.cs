using BusinessObjects;
using DataAccess;
using Repositories.Interfaces;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
	{
		public List<OrderDetail> FindOrderDetailById(int orderId) => OrderDetailDAO.FindOrderDetailById(orderId);
		public void SaveOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.SaveOrderDetail(orderDetail);
	}
}
