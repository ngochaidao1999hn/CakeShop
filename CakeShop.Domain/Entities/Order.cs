using CakeShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Domain.Entities
{
    public class Order
    {
        public int Ord_Id { get; set; }
        public DateTime Ord_CreateDate { get; set; }
        public Guid Ord_User { get; set; }
        public string Ord_CustomerName { get; set; }
        public string Ord_PhoneNumber { get; set; }
        public string Ord_Adress { get; set; }
        public string Ord_Email { get; set; }
        public string Ord_Note { get; set; }
        public OrderEnum Ord_Status { get; set; }
        public DateTime Ord_ShippingDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public User user { get; set; }
    }
}
