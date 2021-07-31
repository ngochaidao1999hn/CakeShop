using CakeShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Infrastructure.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(pro => pro.Pro_Id);
            builder.Property(pro => pro.Pro_Description)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(pro => pro.Pro_Name).IsRequired();
            builder.Property(pro => pro.Pro_Price).IsRequired();
            builder.Property(pro => pro.Pro_Image)
                .HasMaxLength(300)
                .IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.Pro_Category);
        }
    }
}
