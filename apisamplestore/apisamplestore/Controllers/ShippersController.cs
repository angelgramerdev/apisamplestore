using application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apisamplestore.Controllers
{
    [Route("api")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
       private readonly IShipper _shipper;
        public ShippersController(IShipper shipper) 
        { 
            _shipper = shipper;
        }

        [HttpGet]
        [Route("GetShippers")]
        public async Task<IActionResult> GetShippers()
        {
            try
            {
                var res=await _shipper.GetShippers();
                return Ok(res);
            }
            catch(Exception e) 
            {
                return BadRequest();
            }
        
        }
    
    }
}
