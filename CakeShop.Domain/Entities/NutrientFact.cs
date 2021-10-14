using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Domain.Entities
{
    public class NutrientFact
    {
        public int Nutrient_Id { get; set; }
        public int Product_Id { get; set; }
        public int Nutrient_Calories { get; set; }
        public int Nutrient_Calories_from_Fat { get; set; }
        public int Nutrient_Fat { get; set; }
        public int Nutrient_Carbohydrate { get; set; }
        public int Nutrient_Sodium { get; set; }
        public int Nutrient_Cholesterol { get; set; }
        public int Nutrient_Protein { get; set; }
        public Product Product { get; set; }     
    }
}
