using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Dtos.OrderDto
{
    public class OrderDetailDto
    {
        public int Product_Id { get; set; }
        public int Quantity { get; set;}
        public decimal PricePerunit { get; set; }
    }
}
