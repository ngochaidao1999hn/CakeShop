using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Dtos.OrderDto
{
    public class OrderDto
    {
       public List<OrderDetailDto> ListItem { get; set; }
        public DateTime Order_Time { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Mobile_Number { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public Guid User_id { get; set; }
        public string? Note { get; set; }
    }
}
