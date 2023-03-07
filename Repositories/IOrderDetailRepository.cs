using BusinessObjects;

namespace Repositories
{
	public interface IOrderDetailRepository
	{
		List<OrderDetail> FindOrderDetailById(int orderId);
		void SaveOrderDetail(OrderDetail orderDetail);
	}
}
