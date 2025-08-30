using application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apisamplestore.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _employee;
        public EmployeesController(IEmployee employee) 
        { 
            _employee = employee;
        }

        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var res= await _employee.GetEmployees();
                return Ok(res);
            }
            catch (Exception ex) 
            { 
                return BadRequest();
            }
        }

    }
}
