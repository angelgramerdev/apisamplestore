using application.Interfaces;
using domain.Entities;
using domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apisamplestore.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrder _order;
        
        public OrdersController(IOrder order) 
        { 
            _order = order;
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrders(int customerId, int page, int rows) 
        {
            try
            {
                var res=await _order.GetOrders(customerId,page,rows);  
                return Ok(res);
            }
            catch(Exception e) 
            {
                return BadRequest();   
            }
        }

        [HttpPost]
        [Route("SaveOrderDetails")]
        public async Task<IActionResult> SaveOrderDetails(OrderDetailsDomain orderDetails) 
        {
            try
            {
                var res =await _order.SaveOrderDetails(orderDetails);
                return Ok(res);
            }
            catch (Exception e)
            { 
            return BadRequest();
            }
        }
    }
}
