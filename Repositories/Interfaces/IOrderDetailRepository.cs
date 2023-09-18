using BusinessObjects;

namespace Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> FindOrderDetailById(int orderId);
        void SaveOrderDetail(OrderDetail orderDetail);
    }
}
