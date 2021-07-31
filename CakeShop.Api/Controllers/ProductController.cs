using CakeShop.Application.Query;
using CakeShop.Domain.Entities;
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
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;
        public ProductController(IMediator mediator) {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
           return Ok(await _mediator.Send(new GetAllProductQuery()));
        }
    }
}
