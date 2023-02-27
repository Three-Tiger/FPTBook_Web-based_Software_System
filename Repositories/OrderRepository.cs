using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class OrderRepository : IOrderRepository
	{
		public List<Order> GetOrders() => OrderDAO.GetOrders();
		public Order FindOrderById(int orderId) => OrderDAO.FindOrderById(orderId);
		public int SaveOrder(Order order) => OrderDAO.SaveOrder(order);
		public void ChangeStatus(Order order) => OrderDAO.ChangeStatus(order);
		public void DeleteOrder(Order order) => OrderDAO.DeleteOrder(order);
	}
}
