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
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Ord_Id);
            builder.Property(x => x.Ord_Adress)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(x => x.Ord_Email)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(50);
            builder.Property(x => x.Ord_PhoneNumber)
                .HasMaxLength(11)
                .IsRequired();
            builder.Property(x => x.Ord_CustomerName)
                .HasMaxLength(200)
                .IsRequired();
            builder.HasOne(x => x.user).WithMany(x => x.Orders).HasForeignKey(x => x.Ord_User);
        }
    }
}
