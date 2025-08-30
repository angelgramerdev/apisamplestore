using Azure;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Interfaces
{
    public interface ICustomer
    {
        Task<ResponseDomain> GetCustomers(int pages, int rows);
        Task<ResponseDomain> GetCustomerByName(string name);
    }
}
