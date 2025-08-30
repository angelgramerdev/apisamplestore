using Azure;
using domain.Entities;
using domain.Interfaces;
using infrastructure.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Adapters
{
    public class OrderAdapter : IOrderDomain
    {
        private readonly StoreSampleContext _context;

        public OrderAdapter(StoreSampleContext context) 
        { 
            _context = context;
        }

        public async Task<List<OrderDomain>> GetOrders(int customerId, int page, int rows)
        {
            List<OrderDomain> _orders = new List<OrderDomain>();
            try
            {
                var orders =await _context.Orders.Where(o=> o.custid==customerId).Skip(page-1).Take(rows).ToListAsync();
                orders.ForEach(o => {
                    _orders.Add(new OrderDomain{ 
                         OrderId=o.orderid,
                         RequiredDate=o.requireddate,
                         ShipName=o.shipname,
                         ShipCity=o.shipcity,
                         ShippedDate=o.shippeddate,
                         ShipAddress=o.shipaddress
                    });
                });

                
            
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return _orders;
        }

        public async Task<int> SaveOrderDetail(OrderDetailsDomain orderDetail)
        {
            int result = 0;
            try
            {
                result = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC new_order @customerid={orderDetail.CustomerId},@employeeid={orderDetail.EmployeeId},@shipperid={orderDetail.ShiperId},@shipname={orderDetail.ShipName},@shipaddress={orderDetail.ShipAddress},@shipcity={orderDetail.ShipCity},@orderdate={orderDetail.OrderDate},@requireddate={orderDetail.RequiredDate},@shippeddate={orderDetail.ShippedDate},@freight={orderDetail.Freight},@shipcountry={orderDetail.ShipCountry},@productid={orderDetail.ProductId},@unitprice={orderDetail.UnitPrice},@qty={orderDetail.Qty},@discount={orderDetail.Discount}");
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            return result;
        }
    }
}
