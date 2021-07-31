using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Domain.Entities
{
    public class OrderDetail
    {
        public int Detail_Id { get; set; }
        public int Detail_Product { get; set; }
        public decimal Detail_Price { get; set; }
        public int Detail_Quantity { get; set; }
        public int Detail_Ord { get; set; }
        public Product product { get; set; }
        public Order order { get; set; }
    }
}
