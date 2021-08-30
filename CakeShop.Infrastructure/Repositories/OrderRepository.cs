using CakeShop.Domain.Entities;
using CakeShop.Domain.Enums;
using CakeShop.Domain.Interfaces;
using CakeShop.Dtos.OrderDto;
using CakeShop.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(CakeShopDbContext context):base(context){ 
        
        }
        public async Task MakeOrder(OrderDto order)
        {
            //Create New Order
            Order o = new Order() {
               Ord_CreateDate = order.Order_Time,
               Ord_CustomerName = order.First_Name + order.Last_Name,
               Ord_User = order.User_id,
               Ord_Adress = order.Adress,
               Ord_Email = order.Email,
               Ord_PhoneNumber = order.Mobile_Number,
               Ord_Status = OrderEnum.Pending,
               Ord_Note = order.Note
            };
           await _context.Orders.AddAsync(o);

            //Save item list into Order
            foreach (var item in order.ListItem) {
                OrderDetail detail = new OrderDetail() { 
                Detail_Ord = o.Ord_Id,
                Detail_Product = item.Product_Id,
                Detail_Quantity = item.Quantity,
                Detail_Price = item.PricePerunit
               
            };
                await _context.OrderDetails.AddAsync(detail);
            }
        }
    }
}
