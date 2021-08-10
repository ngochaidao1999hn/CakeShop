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
        [HttpGet("{PageNumber}")]
        public async Task<IActionResult> GetProductByPageNumber(int PageNumber) {
            return Ok(await _mediator.Send(new GetListProductWithPageNumberQuery(PageNumber)));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetProductById(int id) {
            return Ok(await _mediator.Send(new GetProductByIdQuery(id)));
        }
        [HttpGet("GetByCategory")]
        public async Task<IActionResult> GetProductByCategory(int Cate_id)
        {
            return Ok(await _mediator.Send(new GetProductWithCategoryQuery(Cate_id)));
        }
    }
}
