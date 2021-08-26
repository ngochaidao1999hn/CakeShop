﻿using CakeShop.Domain.Entities;
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
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int id) {
            var productDetail = new ProductDetailPageDto();
            var httpclient = new HttpClient();
                var Response = await httpclient.GetAsync("https://localhost:5001/api/Product/GetById?id=" + id);
                var Result = await Response.Content.ReadAsStringAsync();
                productDetail =  Newtonsoft.Json.JsonConvert.DeserializeObject<ProductDetailPageDto>(Result);    
                return View(productDetail);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword)
        {
            IEnumerable<Product> ProductList;
            using (var httpclient = new HttpClient())
            {
                var response = await httpclient.GetAsync("https://localhost:5001/api/Product");
                var result = await response.Content.ReadAsStringAsync();
                ProductList = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
            }
            var product_searched = ProductList.Where(p => p.Pro_Name.Contains(keyword));
            return View(product_searched);
       }
    }
}
