using AutoMapper;
using CakeShop.Domain.Entities;
using CakeShop.Domain.Interfaces;
using CakeShop.Dtos.ProductDto;
using CakeShop.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Infrastructure.Repositories
{
    public class ProductRepository :Repository<Product>, IProductRepository
    {   
        public ProductRepository(CakeShopDbContext context) : base(context) {          
        }

        public async Task<ProductDetailPageDto> GetProductDetailwithSimilarProduct(int Pro_id)
        {
            ProductDetailPageDto dto = new ProductDetailPageDto();
            Product p = new Product();
             p =  _context.Products.Find(Pro_id);
            dto.product = new ProductDto() { 
                Pro_Id = p.Pro_Id,
                Pro_Name = p.Pro_Name,
                Pro_Category = p.Pro_Category,
                Pro_Description = p.Pro_Description,
                Pro_Image = p.Pro_Image,
                Pro_Price = p.Pro_Price
            };
            IEnumerable<Product> pList = await _context.Products.Where(p => p.Pro_Category == p.Pro_Category).ToListAsync();
            dto.ProductSimilar = new List<ProductDto>();
            foreach (var item in pList) {
               ProductDto pro = new ProductDto()
                {
                    Pro_Id = item.Pro_Id,
                    Pro_Name = item.Pro_Name,
                    Pro_Category = item.Pro_Category,
                    Pro_Description = item.Pro_Description,
                    Pro_Image = item.Pro_Image,
                    Pro_Price = item.Pro_Price
                };
                dto.ProductSimilar.Add(pro);
            }
            return dto;
        }

        public async Task<IEnumerable<Product>> GetProductListWithCategory(int Cate_id)
        {
            return await _context.Products.Where(pro => pro.Pro_Category == Cate_id).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductWithPage(int Page)
        {
            int Skip = 6 * (Page - 1);
           var ListProduct = await _context.Products.Skip(Skip).Take(6).ToListAsync();
            return ListProduct;

        }
    }
}
