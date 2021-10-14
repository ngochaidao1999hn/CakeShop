using CakeShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Domain.Entities
{
    public class Product
    {
        public int Pro_Id { get; set; }
        public string Pro_Name { get; set; }
        public string Pro_Description { get; set; }
        public decimal Pro_Price { get; set; }
        public string Pro_Image { get; set; }
        public DateTime Pro_ImportDate { get; set; }
        public StatusEnum Pro_Status { get; set; }
        public int Pro_Category { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public NutrientFact NutrientFacts { get; set; }

    }
}
