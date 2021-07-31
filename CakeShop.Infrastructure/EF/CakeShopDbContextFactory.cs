using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Infrastructure.EF
{
    public class CakeShopDbContextFactory : IDesignTimeDbContextFactory<CakeShopDbContext>
    {
        public CakeShopDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CakeShopDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-OA32JNB\\SQLEXPRESS01;Database=CakeShop;Trusted_Connection=True;");

            return new CakeShopDbContext(optionsBuilder.Options);
        }
    }
}
