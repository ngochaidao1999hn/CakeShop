using CakeShop.Domain.Entities;
using CakeShop.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CakeShop.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //List<Product> ListProduct = new List<Product>();
            //using (var httpclient = new HttpClient()) {
            //    var response = await httpclient.GetAsync("https://localhost:5001/api/product/GettopSeller");
            //    var result = await response.Content.ReadAsStringAsync();
            //    ListProduct = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(result);
            //}          
            ViewBag.top5Seller = top5Seller;
            return View();
        }
        public async Task<IActionResult> Menu() {
            List<Product> ListProduct = new List<Product>();
            using (var httpclient = new HttpClient())
            {
                var response = await httpclient.GetAsync("https://localhost:5001/api/product");
                var result = await response.Content.ReadAsStringAsync();
                ListProduct = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(result);
            }
            return View(ListProduct);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs() {
            return View();
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        [Route("/NotFound")]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
