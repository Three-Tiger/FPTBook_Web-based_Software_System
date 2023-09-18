using BusinessObjects;
using DataAccess;
using Repositories.Interfaces;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
	{
		public List<Order> GetOrders() => OrderDAO.GetOrders();
		public List<Order> FindOrderByUserId(string userId) => OrderDAO.FindOrderByUserId(userId);
		public Order FindOrderById(int orderId) => OrderDAO.FindOrderById(orderId);
		public int SaveOrder(Order order) => OrderDAO.SaveOrder(order);
		public void ChangeStatus(Order order) => OrderDAO.ChangeStatus(order);
		public void DeleteOrder(Order order) => OrderDAO.DeleteOrder(order);
	}
}
