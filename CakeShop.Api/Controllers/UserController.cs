
using CakeShop.Domain.Interfaces;
using CakeShop.Dtos.UserDtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _user;
        public UserController(IUserRepository user) {
            _user = user;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginInfo logininfo) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var token = await _user.Authenticate(logininfo);
            if (token == null) {
                return BadRequest("User Name or Password not correct !!");
             }
            return Ok(token);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterInfo registerinfo) {
        
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
             if (registerinfo.Password != registerinfo.ConfirmPassword) {
                return BadRequest("Password and Confirm Password not match");
            }
            LoginInfo User = new LoginInfo()
            {
                UserName = registerinfo.UserName,
                Password = registerinfo.Password,
                RememberMe = true
            };
            if (await _user.Authenticate(User) == null)
            {
                return Ok(await _user.Register(registerinfo));
            }
            return BadRequest("User already exist");
        }


    }
}
