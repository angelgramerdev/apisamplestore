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
    public class EmployeeService : IEmployee
    {
        private readonly IEmployeeDomain _employee;
        public EmployeeService(IEmployeeDomain employee) 
        { 
            _employee = employee;
        }    
        
        public async Task<ResponseDomain> GetEmployees()
        {
            ResponseDomain response = null;
            List<EmployeeDomain> _employees= new List<EmployeeDomain>();    
            try 
            { 
                var employees= await _employee.GetEmployees();
                response = GetResponse("OK", true);              
                response.employees = employees;
               
            }
            catch(Exception e) 
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
    }
}
