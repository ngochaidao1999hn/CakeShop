using CakeShop.AdminApp.Models;
using CakeShop.Domain.Entities;
using CakeShop.Dtos.OrderDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CakeShop.AdminApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
                var httpclient = new HttpClient();
                var token = HttpContext.Session.GetString("Token");
                httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var response = await httpclient.GetAsync("https://localhost:5001/api/Order/GetAll");
                var results = await response.Content.ReadAsStringAsync();
                var listorder =  Newtonsoft.Json.JsonConvert.DeserializeObject<List<Order>>(results);         
                return View(listorder);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
