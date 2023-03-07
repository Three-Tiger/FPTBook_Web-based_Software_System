using BusinessObjects;

namespace Repositories
{
	public interface IOrderRepository
	{
		List<Order> GetOrders();
		List<Order> FindOrderByUserId(string userId);
		Order FindOrderById(int orderId);
		int SaveOrder(Order order);
		void ChangeStatus(Order order);
		void DeleteOrder(Order order);
	}
}
