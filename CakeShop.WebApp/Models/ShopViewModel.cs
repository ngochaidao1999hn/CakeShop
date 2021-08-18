using CakeShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.WebApp.Models
{
    public class ShopViewModel
    {
        public decimal PageTotal { get; set; }
        public IEnumerable<Category> CategoriesList { get; set; }
    }
}
