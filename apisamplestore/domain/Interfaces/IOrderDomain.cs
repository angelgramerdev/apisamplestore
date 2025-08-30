using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Interfaces
{
    public interface IOrderDomain
    {
        Task<List<OrderDomain>> GetOrders(int customerId, int page, int rows);
        Task<int> SaveOrderDetail(OrderDetailsDomain orderDetail);
    }
}
