using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Dtos.CategoryDto
{
    public class CategoryWithProductCount
    {
        public int Cate_Id { get; set; }
        public string cate_Name { get; set; }
        public int Product_Quantity { get; set; }
    }
}
