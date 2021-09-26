using CakeShop.Domain.Entities;
using CakeShop.Dtos.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CakeShop.WebApp.Controllers
{
    public class BaseController : Controller
    {
       public List<Product> top5Seller = null;
       public List<CategoryWithProductCount> categoryWithProducts = null;
        public BaseController()
        {
            top5Seller = getTop5Seller().Result;
            categoryWithProducts = GetCategoryWithProductCounts().Result;
        }
        public async Task<List<Product>> getTop5Seller() {
            List<Product> ListProduct = new List<Product>();
            using (var httpclient = new HttpClient())
            {
                var response = await httpclient.GetAsync("https://localhost:5001/api/product/GettopSeller");
                var result = await response.Content.ReadAsStringAsync();
                ListProduct = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(result);
            }
            return ListProduct;
        }
        public async Task<List<CategoryWithProductCount>> GetCategoryWithProductCounts() {
            using (var httpclient = new HttpClient())
            {
                var response = await httpclient.GetAsync("https://localhost:5001/api/Categories/GetCategoryWithProductCounts");
                var result = await response.Content.ReadAsStringAsync();
               return Newtonsoft.Json.JsonConvert.DeserializeObject<List<CategoryWithProductCount>>(result);
            }
        }
        
    }
}
