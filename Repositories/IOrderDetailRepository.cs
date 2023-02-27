using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public interface IOrderDetailRepository
	{
		List<OrderDetail> FindOrderDetailById(int orderId);
		void SaveOrderDetail(OrderDetail orderDetail);
	}
}
