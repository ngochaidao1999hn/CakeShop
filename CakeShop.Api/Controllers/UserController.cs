using CakeShop.Application.Command;
using CakeShop.Application.Query;
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
        private IMediator _mediator;
        public UserController(IMediator mediator) {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginInfo logininfo) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var token = await _mediator.Send(new LoginCommand(logininfo));
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
            if (await _mediator.Send(new LoginCommand(User)) == null)
            {
                return Ok(await _mediator.Send(new RegisterCommand(registerinfo)));
            }
            return BadRequest("User already exist");
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid Id) {
            return Ok(await _mediator.Send(new GetUserByIdQuery(Id)));
        }

    }
}
