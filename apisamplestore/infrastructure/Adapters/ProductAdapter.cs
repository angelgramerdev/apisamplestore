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
    public class ProductAdapter : IProductDomain
    {
        private readonly StoreSampleContext _context;

        public ProductAdapter(StoreSampleContext context) 
        { 
            _context = context;
        }

        public async Task<List<ProductDomain>> GetProducts()
        {
            List<ProductDomain> products = new List<ProductDomain>();
            try
            {
                List<Product> _products = await _context.Products.ToListAsync();
                _products.ForEach(p=> {
                    products.Add(new ProductDomain { 
                     ProductId=p.productid,
                     ProductName=p.productname,
                    });             
                });
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return products;
        }
    }
}
