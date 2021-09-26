using CakeShop.Domain.Entities;
using CakeShop.Domain.Interfaces;
using CakeShop.Dtos.CategoryDto;
using CakeShop.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Infrastructure.Repositories
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(CakeShopDbContext context) : base(context) { 
        
        }

        public async Task<List<CategoryWithProductCount>> getCategoriesWithProductCount()
        {
            List<CategoryWithProductCount> ListCategories = new List<CategoryWithProductCount>();
           //await _context.Set<CategoryWithProductCount>().FromSqlRaw("EXEC getCountProductbyCategories").ToListAsync();
            var result= await _context.Categories.Include(cate => cate.Products).OrderBy(pro => pro.Products.Count).ToListAsync();
            foreach (var item in result) {
                CategoryWithProductCount c = new CategoryWithProductCount()
                {
                    Cate_Id = item.Cate_Id,
                    cate_Name = item.Cate_Name,
                    Product_Quantity = item.Products.Count
                };
                ListCategories.Add(c);
            }
            return ListCategories;
                      
        }
    }
}
