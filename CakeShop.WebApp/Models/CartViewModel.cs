using CakeShop.Domain.Entities;
using CakeShop.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.WebApp.Models
{
    public class CartViewModel
    {
        public ProductDto product { get; set; }
        public int Quantity { get; set; }
    }
}
