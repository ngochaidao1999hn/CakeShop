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

namespace CakeShop.AdminApp.Controllers
{
    public class UserController : Controller
    {
        private IConfiguration _config;
        public UserController(IConfiguration config) {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginInfo loginInfo) {
            string token;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(loginInfo);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            using (var httpclient = new HttpClient()) {
                var response = await httpclient.PostAsync("https://localhost:5001/api/User/Login", content);
                if (response.IsSuccessStatusCode)
                {
                    token = await response.Content.ReadAsStringAsync();
                    HttpContext.Session.SetString("Token", token);
                    var UserClaimPrincipal = ValidateToken(token);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        IsPersistent = loginInfo.RememberMe

                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, UserClaimPrincipal);
                    return RedirectToAction("Index", "Home");
                }
                else {
                    ViewBag.Error = "username or password not correct";
                }
                return View();
            }
        }
        public  ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _config["Jwt:Issuer"];
            validationParameters.ValidIssuer =   _config["Jwt:Issuer"];
            validationParameters.IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);


            return principal;
        }
    }
}
