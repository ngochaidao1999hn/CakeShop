using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Domain.Entities
{
    public class Category
    {
        public int Cate_Id { get; set; }
        public string Cate_Name { get; set; }
        public string Cate_Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
