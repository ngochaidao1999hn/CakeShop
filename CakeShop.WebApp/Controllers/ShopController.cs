using CakeShop.Domain.Entities;
using CakeShop.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CakeShop.WebApp.Controllers
{
    public class ShopController : BaseController
    {
        public async Task<IActionResult> Index(int? page)
        {
            ShopViewModel viewmodel = new ShopViewModel();
            IEnumerable<Product>ListProduct = null;
            int productCount = 0;
            if (page == null) {
                page = 1;
            }
            using (var httpclient = new HttpClient()) {
                var Response = await httpclient.GetAsync("https://localhost:5001/api/product/"+page);
                var Results = await Response.Content.ReadAsStringAsync();
                ListProduct = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Product>>(Results);
                var ResponseProductCount = await httpclient.GetAsync("https://localhost:5001/api/product");
                productCount =Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Product>>( await ResponseProductCount.Content.ReadAsStringAsync()).Count();
                viewmodel.CategoriesList = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Category>>(await httpclient.GetAsync("https://localhost:5001/api/category")
                    .Result
                    .Content
                    .ReadAsStringAsync());
                    
            }
            viewmodel.PageTotal = productCount / 6;
            viewmodel.PageTotal = Math.Ceiling(viewmodel.PageTotal);
            if (productCount % viewmodel.PageTotal > 0) {
                viewmodel.PageTotal++;
            }
            
            ViewBag.ShopViewModel = viewmodel;
            ViewBag.CurrentPage = page;
            ViewBag.top5Seller = top5Seller;
            ViewBag.Categories = categoryWithProducts;
            return View(ListProduct);
        }
        public async Task<IActionResult> Category(int? Cate_id)
        {
            ShopViewModel viewmodel = new ShopViewModel();
            IEnumerable<Product> ListProduct = null;          
            using (var httpclient = new HttpClient())
            {
                var Response = await httpclient.GetAsync("https://localhost:5001/api/product/GetByCategory?Cate_id=" + Cate_id);
                var Results = await Response.Content.ReadAsStringAsync();
                ListProduct = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Product>>(Results);
                viewmodel.CategoriesList = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Category>>(await httpclient.GetAsync("https://localhost:5001/api/category")
                    .Result
                    .Content
                    .ReadAsStringAsync());

            }
            ViewBag.top5Seller = top5Seller;
            ViewBag.Categories = categoryWithProducts;
            return View(ListProduct);
        }
    }
}
