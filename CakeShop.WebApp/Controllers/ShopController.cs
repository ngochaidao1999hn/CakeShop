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
    public class ShopController : Controller
    {
        public async Task<IActionResult> Index(int? page)
        {
            ShopViewModel viewmodel = new ShopViewModel();
            IEnumerable<Product>ListProductbyPage = null;
            int productCount = 0;
            if (page == null) {
                page = 1;
            }
            using (var httpclient = new HttpClient()) {
                var Response = await httpclient.GetAsync("https://localhost:5001/api/product/"+page);
                var Results = await Response.Content.ReadAsStringAsync();
                ListProductbyPage = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Product>>(Results);
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
            return View(ListProductbyPage);
        }
    }
}
