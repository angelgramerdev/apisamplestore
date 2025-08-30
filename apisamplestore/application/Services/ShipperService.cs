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
    public class ShipperService : IShipper
    {
       private readonly IShipperDomain _shipper;

        public ShipperService(IShipperDomain shipper) 
        { 
            _shipper = shipper;
        }

        public async Task<ResponseDomain> GetShippers()
        {
            ResponseDomain response = null;
            try
            {
                var shippers= await _shipper.GetShippers();
                response = GetResponse("Ok", true);
                response.shippers = shippers;   
            }
            catch (Exception e) 
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
