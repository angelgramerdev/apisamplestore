using application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Entities;
using domain.Interfaces;
using System.Net;

namespace application.Services
{
    public class CustomerService:ICustomer
    {
        private readonly ICustomerDomain _customerDomain;

        public CustomerService(ICustomerDomain customerDomain) 
        { 
            _customerDomain = customerDomain;
        }

        public async Task<ResponseDomain> GetCustomers(int pages, int rows) 
        {
            ResponseDomain response = null;
            try
            {
                response = GetResponse("OK", true);
                response.customers=await _customerDomain.GetCustomers(pages,rows);
                response.customers.ForEach(c=> c.PredictedDate=c.LastOrderDate.AddDays(c.DiffDays));

                return response;    
            }
            catch(Exception e) 
            {

                response = GetResponse("BadRequest", false);
                return response;
            }
        }

        public ResponseDomain GetResponse(string message, bool isGood) 
        {
            ResponseDomain response = new();
            if (isGood) 
            {
                response.Status = HttpStatusCode.OK;
                response.Message = message; 
            }

            response.Status = HttpStatusCode.BadRequest;
            response.Message = message;
            return response;
        }
    
    }
}
