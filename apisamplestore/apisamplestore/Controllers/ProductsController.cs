using application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apisamplestore.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _product;
        
        public ProductsController(IProduct product) 
        {
            _product = product;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult>GetProducts()
        {
            try
            {
                var res= await _product.GetProducts();  
                return Ok(res); 
            }
            catch (Exception e) 
            { 
                return BadRequest();   
            }
        }    

    }
}
