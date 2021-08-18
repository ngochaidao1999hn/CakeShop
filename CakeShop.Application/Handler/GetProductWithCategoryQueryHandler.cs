using CakeShop.Application.Query;
using CakeShop.Domain.Entities;
using CakeShop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CakeShop.Application.Handler
{
    public class GetProductWithCategoryQueryHandler : IRequestHandler<GetProductWithCategoryQuery, IEnumerable<Product>>
    {
        private IProductRepository _productrepository;
        public GetProductWithCategoryQueryHandler(IProductRepository productRepository) {
            _productrepository = productRepository;
        }
        public async Task<IEnumerable<Product>> Handle(GetProductWithCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _productrepository.GetProductListWithCategory(request.Cate_id);
        }
    }
}
