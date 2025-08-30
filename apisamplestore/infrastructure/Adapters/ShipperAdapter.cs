using domain.Entities;
using domain.Interfaces;
using infrastructure.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Adapters
{
    public class ShipperAdapter : IShipperDomain
    {
        private readonly StoreSampleContext _context;
        public ShipperAdapter(StoreSampleContext context) 
        { 
            _context = context;
        }
        public async Task<List<ShipperDomain>> GetShippers()
        {
            List<ShipperDomain> shippers = new List<ShipperDomain>();   
            try
            {
                var _shippers =await _context.Shippers.ToListAsync();
                _shippers.ForEach(s=> {
                    shippers.Add(new ShipperDomain
                    {
                         CompanyName=s.companyname,
                         ShipperId=s.shipperid
                    });
                });
            }
            catch (Exception e) 
            {
                e.Message.ToString();
            }
            return shippers;
        }
    }
}
