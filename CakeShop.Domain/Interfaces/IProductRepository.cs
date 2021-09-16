using CakeShop.Domain.Entities;
using CakeShop.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Domain.Interfaces
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductWithPage(int Page);
        Task<IEnumerable<Product>> GetProductListWithCategory(int Cate_id);
        Task<ProductDetailPageDto> GetProductDetailwithSimilarProduct(int Pro_id);
        Task<IEnumerable<Product>> GetTopSaleProducts();
    }
}
