using CakeShop.Domain.Entities;
using CakeShop.Dtos.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Domain.Interfaces
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<List<CategoryWithProductCount>> getCategoriesWithProductCount();
    }
}
