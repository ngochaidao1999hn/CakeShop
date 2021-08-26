using CakeShop.Domain.Entities;
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
                return View(cart);
            }
            return RedirectToAction("Index", "Home");
        }
        public void AddProductToCart(int Pro_id, int Quantity)
        {
            List<CartViewModel> cart = new List<CartViewModel>();
            CartViewModel Detail = new CartViewModel();
            var p = GetProductById(Pro_id);
            Detail.product = p.Result;
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
        public async Task<ProductDto> GetProductById(int Id)
        {
            ProductDetailPageDto p = null;
            using (var httpclient = new HttpClient())
            {
                var ProductbyIdResponse = await httpclient.GetAsync("https://localhost:5001/api/Product/GetById?id=" + Id);
                var ProductbyIdResult = await ProductbyIdResponse.Content.ReadAsStringAsync();
                p = JsonConvert.DeserializeObject<ProductDetailPageDto>(ProductbyIdResult);
            }
            return p.product;
        }
    }
}
