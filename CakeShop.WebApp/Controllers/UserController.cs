
using CakeShop.Dtos.UserDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.WebApp.Controllers
{
    public class UserController : Controller
    {
        private IConfiguration _configuration;
        public UserController(IConfiguration configuration) {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login() {
           await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginInfo LoginRequest) {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(LoginRequest);
            var context = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            string token,error;
            using (HttpClient client = new HttpClient()) {
                var Response = await client.PostAsync("https://localhost:5001/api/User/Login",context);
                if (Response.IsSuccessStatusCode)
                {
                    token = await Response.Content.ReadAsStringAsync();
                    HttpContext.Session.SetString("Token", token);
                    var UserClaimPrincipal = ValidateToken(token);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        IsPersistent = LoginRequest.RememberMe

                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, UserClaimPrincipal, authProperties);
                    return RedirectToAction("Index", "Home");
                }
                else { 
                    error = await Response.Content.ReadAsStringAsync();
                    ViewBag.Error = error;
                    return View(LoginRequest);
                }
            }                                        
        }
        [HttpPost]
        public IActionResult Register(RegisterInfo RegisterRequest) {
            return View();
        }
        private ClaimsPrincipal ValidateToken(string jwt) {
            IdentityModelEventSource.ShowPII = true;
            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.ValidateLifetime = true;
            validationParameters.ValidIssuer = _configuration["Jwt:Issuer"];
            validationParameters.ValidAudience = _configuration["Jwt:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwt, validationParameters,out validatedToken);
            return principal;
        }
        public async Task<IActionResult> Logout() {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Home");
        }
    }
}
