using CakeShop.Domain.Entities;
using CakeShop.Dtos.ProductDto;
using CakeShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CakeShop.WebApp.Controllers
{
    public class ProductsController : BaseController
    { 
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id) {
            using (var httpclient = new HttpClient())
            {
                var Response = await httpclient.GetAsync("https://localhost:5001/api/Product/GetById?id=" + id);
                if (Response.IsSuccessStatusCode)
                {
                    var Result = await Response.Content.ReadAsStringAsync();

                    Product p = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(Result);
                    if (p == null) {
                        return RedirectToAction("Index", "Home");
                    }
                    return View(p);
                }
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<JsonResult> Search(string? keyword)
        {
            if (keyword == null) {
                return Json(new { });
            }
            IEnumerable<Product> ProductList;
            using (var httpclient = new HttpClient())
            {
                var response = await httpclient.GetAsync("https://localhost:5001/api/Product");
                var result = await response.Content.ReadAsStringAsync();
                ProductList = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
            }
            var product_searched = ProductList.Where(p => p.Pro_Name.Contains(keyword));
            return Json(product_searched) ;
       }
    }
}
