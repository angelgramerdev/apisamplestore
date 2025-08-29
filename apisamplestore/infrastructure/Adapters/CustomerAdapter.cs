using infrastructure.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Interfaces;
using domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace infrastructure.Adapters
{
    public class CustomerAdapter : ICustomerDomain
    {

        private readonly StoreSampleContext _context;

        public CustomerAdapter(StoreSampleContext context)
        { 
            _context = context; 
        }

        public async Task<List<CustomerDomain>> GetCustomers(int pages,int rows)
        {
            List<CustomerDomain> _customers = null;


            try
            {
                var customers = _context.Database.SqlQuery<CustomerDomain>($"EXEC getcustomers {pages},{rows}");
                _customers = await customers.ToListAsync();
                 return _customers;
            }
            catch (Exception e) 
            {
                e.Message.ToString();
            }
            
            return _customers;                       
        }
    }
}
