using CakeShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.WebApp.Models
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Product> Similar_Product { get; set; }
    }
}
