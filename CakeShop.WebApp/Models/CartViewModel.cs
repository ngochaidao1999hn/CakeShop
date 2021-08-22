using CakeShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.WebApp.Models
{
    public class CartViewModel
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
    }
}
