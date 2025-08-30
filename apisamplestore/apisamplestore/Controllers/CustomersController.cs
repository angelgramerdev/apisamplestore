using application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apisamplestore.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomer _customerService;
        public CustomersController(ICustomer customerService) 
        { 
            _customerService=customerService;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IActionResult> GetCustomers(int pages, int rows) 
        {
            try
            {
                var res=await _customerService.GetCustomers(pages, rows);
                return Ok(res);
            
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);  
            }
        }

        [HttpGet]
        [Route("GetCustomerByName")]
        public async Task<IActionResult> GetCustomerByName(string name) 
        {
            try
            {
                var res=await _customerService.GetCustomerByName(name);
                return Ok(res); 
            }
            catch (Exception e) 
            {
                return BadRequest();
            }
        }
    }
}
