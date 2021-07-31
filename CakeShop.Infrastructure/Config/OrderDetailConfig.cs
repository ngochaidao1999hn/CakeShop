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
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.Detail_Id);
            builder.Property(x => x.Detail_Price).IsRequired();
            builder.Property(x => x.Detail_Quantity).IsRequired();
            builder.HasOne(x => x.order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.Detail_Ord);
            builder.HasOne(x => x.product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.Detail_Product);
        }
    }
}
