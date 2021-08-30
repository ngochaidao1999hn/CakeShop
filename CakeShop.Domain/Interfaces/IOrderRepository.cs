using CakeShop.Domain.Entities;
using CakeShop.Dtos.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Domain.Interfaces
{
    public interface IOrderRepository:IRepository<Order>
    {
        Task MakeOrder(OrderDto order);
        
    }
}
