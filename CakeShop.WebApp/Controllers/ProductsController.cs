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
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int id) {
            ProductDetailViewModel productDetailViewModel = new ProductDetailViewModel();
            using (var httpclient = new HttpClient()) {
                var ProductbyIdResponse = await httpclient.GetAsync("https://localhost:5001/api/Product/GetById?id=" + id);
                var ProductbyIdResult = await ProductbyIdResponse.Content.ReadAsStringAsync();
                productDetailViewModel.Product = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(ProductbyIdResult);
                var SimilarProductResponse = await httpclient.GetAsync("https://localhost:5001/api/Product/GetByCategory?Cate_id=" + productDetailViewModel.Product.Pro_Category);
                var SimilarProductResult = await SimilarProductResponse.Content.ReadAsStringAsync();
                productDetailViewModel.Similar_Product = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Product>>(SimilarProductResult);
            }
                return View(productDetailViewModel);
        }
    }
}
