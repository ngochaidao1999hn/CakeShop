using CakeShop.Domain.Interfaces;
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
    public class CategoriesController : ControllerBase
    {
        private IUnitofWork _unitofwork;
        public CategoriesController(IUnitofWork unitofWork)
        {
            _unitofwork = unitofWork;
        }
        [HttpGet("GetCategoryWithProductCounts")]
        public async Task<IActionResult> GetCategoryWithProductCounts()
        {

            return Ok(await _unitofwork.CategoryRepository.getCategoriesWithProductCount());
        }
    }
}
