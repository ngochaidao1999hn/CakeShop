using CakeShop.Domain.Entities;
using CakeShop.Dtos.OrderDto;
using CakeShop.Dtos.ProductDto;
using CakeShop.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private JsonSerializerSettings settings = new JsonSerializerSettings();
        private CookieOptions options = new CookieOptions();       
        public OrdersController() {
            // This tells your serializer that multiple references are okay.
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            options.Expires = DateTime.Now.AddHours(1);
        }
        public IActionResult Cart()
        {
            if (Request.Cookies["cart"] != null)
            {
                var cart = JsonConvert.DeserializeObject<List<CartViewModel>>(Request.Cookies["cart"]);
                return View(cart);
            }
            return RedirectToAction("Index","Home");

        }
        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            if (Request.Cookies["cart"] != null)
            {
                var cart = JsonConvert.DeserializeObject<List<CartViewModel>>(Request.Cookies["cart"]);
                ViewBag.cart = cart;
                return View(new OrderDto());
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderDto o) {
            if (!ModelState.IsValid) {
                var cart = JsonConvert.DeserializeObject<List<CartViewModel>>(Request.Cookies["cart"]);
                ViewBag.cart = cart;
                return View(o);
            }
            o.ListItem = new List<OrderDetailDto>();
            foreach (var item in JsonConvert.DeserializeObject<List<CartViewModel>>(Request.Cookies["cart"])) {
                OrderDetailDto detail = new OrderDetailDto() {
                    Product_Id = item.product.Pro_Id,
                    Quantity = item.Quantity,
                    PricePerunit = item.product.Pro_Price
                };
                o.ListItem.Add(detail);
            }
            o.Order_Time = DateTime.Now;
            o.User_id = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(o);
            var context = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient()) {
                var token = HttpContext.Session.GetString("Token");
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer "+token);
               var response = await httpClient.PostAsync("https://localhost:5001/api/Order", context);
                if (response.IsSuccessStatusCode) {
                    Response.Cookies.Delete("cart");
                    TempData["sucess"] = true;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var cart = JsonConvert.DeserializeObject<List<CartViewModel>>(Request.Cookies["cart"]);
                    ViewBag.cart = cart;
                    return View(o);
                }

            }

        }
        public async Task AddProductToCart(int Pro_id, int Quantity)
        {
            List<CartViewModel> cart = new List<CartViewModel>();
            CartViewModel Detail = new CartViewModel();
            var p = await GetProductById(Pro_id);
            Detail.product = p;
            Detail.Quantity = Quantity;
            cart.Add(Detail);
            var CookieCart = Request.Cookies["cart"];
            if (CookieCart != null)
            {
                List<CartViewModel> existing =JsonConvert.DeserializeObject<List<CartViewModel>>(CookieCart);
                if (existing.Exists(e => e.product.Pro_Id == Detail.product.Pro_Id))
                {
                    existing.Where(p => p.product.Pro_Id == Pro_id).ToList().ForEach(i => i.Quantity += Detail.Quantity);
                }
                else
                {
                    existing.Add(Detail);
                }
                Response.Cookies.Delete("cart");
                Response.Cookies.Append("cart",JsonConvert.SerializeObject(existing, settings), options);
            }
            else
            {       
                Response.Cookies.Append("cart",JsonConvert.SerializeObject(cart, settings), options);
            }
        }
        public void RemoveFromCart(int index) {
            if (Request.Cookies["cart"] != null)
            {
                List<CartViewModel> existing = JsonConvert.DeserializeObject<List<CartViewModel>>(Request.Cookies["cart"]);
                existing.RemoveAt(index);
                if (existing.Count > 0)
                {
                    Response.Cookies.Delete("cart");
                    Response.Cookies.Append("cart", JsonConvert.SerializeObject(existing, settings), options);
                }
                Response.Cookies.Delete("cart");
            }


        }
        public async Task<ProductDto> GetProductById(int Id)
        {
            
            using (var httpclient = new HttpClient())
            {
                var ProductbyIdResponse = await httpclient.GetAsync("https://localhost:5001/api/Product/GetById?id=" + Id);
                var ProductbyIdResult = await ProductbyIdResponse.Content.ReadAsStringAsync();
                var p = JsonConvert.DeserializeObject<Product>(ProductbyIdResult);
                var productDto = new ProductDto()
                {
                    Pro_Id = p.Pro_Id,
                    Pro_Category = p.Pro_Category,
                    Pro_Description = p.Pro_Description,
                    Pro_Image = p.Pro_Image,
                    Pro_Name = p.Pro_Name,
                    Pro_Price = p.Pro_Price
                };
                return productDto;
            }
            
        }
    }
}
