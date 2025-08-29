using application.Interfaces;
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
        public async Task<IActionResult> GetOrders(int customerId) 
        {
            try
            {
                var res=await _order.GetOrders(customerId);  
                return Ok(res);
            }
            catch(Exception e) 
            {
                return BadRequest();   
            }
        }
    }
}
