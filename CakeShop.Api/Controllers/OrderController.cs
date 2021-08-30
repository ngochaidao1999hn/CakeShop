
using CakeShop.Domain.Entities;
using CakeShop.Domain.Enums;
using CakeShop.Domain.Interfaces;
using CakeShop.Dtos.OrderDto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private IUnitofWork _unitofWork;
        public OrderController(IUnitofWork unitofWork) {
            _unitofWork = unitofWork;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]OrderDto order) {
            if (!ModelState.IsValid) {
                return BadRequest("Error");
            }
            Order o = new Order()
            {
                Ord_User = order.User_id,
                Ord_Adress = order.Adress,
                Ord_CreateDate = order.Order_Time,
                Ord_CustomerName = order.Last_Name + order.First_Name,
                Ord_Email = order.Email,
                Ord_PhoneNumber = order.Mobile_Number,
                Ord_Status = OrderEnum.Pending,
                Ord_Note = order.Note
            };
            _unitofWork.OrderRepository.Create(o);
           await _unitofWork.Commit();
            foreach (var item in order.ListItem)
            {
                OrderDetail detail = new OrderDetail()
                {

                    Detail_Product = item.Product_Id,
                    Detail_Quantity = item.Quantity,
                    Detail_Price = item.PricePerunit

                };
                _unitofWork.OrderDetailRepository.Create(detail);
                detail.Detail_Ord = o.Ord_Id;

            }
           await _unitofWork.Commit();
            return Ok();
        }
    }
}
