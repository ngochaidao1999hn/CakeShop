using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Dtos.ProductDto
{
    public class ProductDto
    {
        public int Pro_Id { get; set; }
        public string Pro_Name { get; set; }
        public string Pro_Description { get; set; }
        public decimal Pro_Price { get; set; }
        public string Pro_Image { get; set; }
        public int Pro_Category { get; set; }
    }
}
