using CakeShop.Domain.Entities;
using CakeShop.Domain.Interfaces;
using CakeShop.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Infrastructure.Repositories
{
    public class ProductRepository :Repository<Product>, IProductRepository
    {
        public ProductRepository(CakeShopDbContext context) : base(context) { 
        
        }

        public async Task<IEnumerable<Product>> GetProductWithPage(int Page)
        {
            int Skip = 6 * (Page - 1);
           var ListProduct = await _context.Products.Skip(Skip).Take(6).ToListAsync();
            return ListProduct;

        }
    }
}
