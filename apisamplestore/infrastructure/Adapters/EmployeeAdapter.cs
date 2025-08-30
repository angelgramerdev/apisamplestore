using domain.Entities;
using domain.Interfaces;
using infrastructure.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Adapters
{
    public class EmployeeAdapter : IEmployeeDomain
    {
        private readonly StoreSampleContext _context;

        public EmployeeAdapter(StoreSampleContext context) 
        { 
            _context = context;
        }

        public async Task<List<EmployeeDomain>> GetEmployees()
        {
            List<EmployeeDomain> _employees = new List<EmployeeDomain>();
            try
            {
                var employees =await _context.Employees.ToListAsync();
                employees.ForEach(e => {
                    _employees.Add(new EmployeeDomain { 
                     EmpId=e.empid,
                      FullName=e.firstname+ (e.lastname==null ? "":e.lastname)
                    });
                });
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return _employees;
        }
    }
}
