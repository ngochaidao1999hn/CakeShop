using CakeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Infrastructure.Config
{
    public class NutrientFactsConfig : IEntityTypeConfiguration<NutrientFact>
    {
        public void Configure(EntityTypeBuilder<NutrientFact> builder)
        {
            builder.HasKey(x=>x.Nutrient_Id);
            builder.Property(x => x.Nutrient_Fat).IsRequired();
            builder.Property(x => x.Nutrient_Protein).IsRequired();
            builder.Property(x => x.Nutrient_Sodium).IsRequired();
            builder.Property(x => x.Nutrient_Carbohydrate).IsRequired();
            builder.Property(x => x.Nutrient_Cholesterol).IsRequired();
            builder.Property(x => x.Nutrient_Calories).IsRequired();
            builder.Property(x => x.Nutrient_Calories_from_Fat).IsRequired();
            builder.HasOne(x => x.Product).WithOne(x => x.NutrientFacts).HasForeignKey<NutrientFact>(x => x.Product_Id);
        }
    }
}
