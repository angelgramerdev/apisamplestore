using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Interfaces
{
    public interface IOrder
    {
        Task<ResponseDomain> GetOrders(int customerId, int page, int rows);
        Task<int> SaveOrderDetails(OrderDetailsDomain orderDetails);
    }
}
