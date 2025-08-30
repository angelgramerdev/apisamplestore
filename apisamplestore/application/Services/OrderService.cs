using application.Interfaces;
using domain.Entities;
using domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace application.Services
{
    public class OrderService : IOrder
    {
        
        private readonly IOrderDomain _order;
        public OrderService(IOrderDomain order) 
        { 
            _order = order;
        }   

        public async Task<ResponseDomain> GetOrders(int customerId,int page,int rows)
        {
            ResponseDomain response = null;
            try
            {
                response = GetResponse("OK",true);
                var orders =await _order.GetOrders(customerId, page, rows);  
                response.orders = orders;   
                
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            return response;
        }

        public ResponseDomain GetResponse(string message, bool isGood)
        {
            ResponseDomain response = new();
            if (isGood)
            {
                response.Status = HttpStatusCode.OK;
                response.Message = message;
                return response;
            }

            response.Status = HttpStatusCode.BadRequest;
            response.Message = message;
            return response;
        }

        public async Task<int> SaveOrderDetails(OrderDetailsDomain orderDetail)
        {
            var result = 0;
            try
            {
                result =await _order.SaveOrderDetail(orderDetail);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return result;
        }
    }
}
