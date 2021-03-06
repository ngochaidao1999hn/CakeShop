using CakeShop.Domain.Entities;
using CakeShop.Domain.Interfaces;
using CakeShop.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Infrastructure.Repositories
{
    public class OrderDetailRepository:Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(CakeShopDbContext context) : base(context) { 
        
        }
    }
}
