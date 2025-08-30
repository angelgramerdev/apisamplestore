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
    public class ProductService : IProduct
    {
        private readonly IProductDomain _product;

        public ProductService(IProductDomain product)
        { 
            _product = product;
        }
        
        public async Task<ResponseDomain> GetProducts()
        {
            ResponseDomain response = null;
            
            try
            {
                var products=await _product.GetProducts();
                response = GetResponse("OK", true);
                response.products=products; 
              
                return response;    
            }
            catch (Exception e)
            {
                return GetResponse("BadRequest",false);
            }
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
