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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Cate_Id);
            builder.Property(x => x.Cate_Name).IsRequired();
            builder.Property(x => x.Cate_Description)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
