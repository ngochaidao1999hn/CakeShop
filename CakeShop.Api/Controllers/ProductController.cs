
using CakeShop.Domain.Entities;
using CakeShop.Domain.Interfaces;
using CakeShop.Dtos.ProductDto;
using Microsoft.AspNetCore.Authorization;
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
        
        private IUnitofWork _unitofWork;
        public ProductController(IUnitofWork unitofWork) {
            _unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
           
           return Ok(await _unitofWork.ProductRepository.GetAll());
        }
        [HttpGet("{PageNumber}")]
        public async Task<IActionResult> GetProductByPageNumber(int PageNumber) {
            return Ok(await _unitofWork.ProductRepository.GetProductWithPage(PageNumber));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetProductById(int id) {
            return Ok( await _unitofWork.ProductRepository.GetById(id));
        }
        [HttpGet("GetByCategory")]
        public async Task<IActionResult> GetProductByCategory(int Cate_id)
        {
            return Ok(await _unitofWork.ProductRepository.GetProductListWithCategory(Cate_id));
        }
        [HttpGet("GettopSeller")]
        public async Task<IActionResult> GetTopSeller() {
            return Ok(await _unitofWork.ProductRepository.GetTopSaleProducts());
        }
    }
}
