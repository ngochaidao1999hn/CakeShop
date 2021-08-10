using CakeShop.Application.Command;
using CakeShop.Application.Query;
using CakeShop.Domain.Viewmodels;
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
        public async Task<IActionResult> Login([FromForm]LoginInfo logininfo) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var token = await _mediator.Send(new LoginCommand(logininfo));
            if (token == null) {
                return BadRequest("User Name or Password not correct !!");
             }
            return Ok(new {Token= token });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterInfo registerinfo) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            return Ok(await _mediator.Send(new RegisterCommand(registerinfo)));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid Id) {
            return Ok(await _mediator.Send(new GetUserByIdQuery(Id)));
        }

    }
}
