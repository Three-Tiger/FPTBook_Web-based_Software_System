using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public interface IOrderRepository
	{
		List<Order> GetOrders();
		Order FindOrderById(int orderId);
		void SaveOrder(Order order);
		void ChangeStatus(Order order);
		void DeleteOrder(Order order);
	}
}
