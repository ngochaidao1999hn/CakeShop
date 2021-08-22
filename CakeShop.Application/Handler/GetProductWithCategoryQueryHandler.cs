using CakeShop.Application.Query;
using CakeShop.Domain.Entities;
using CakeShop.Domain.Interfaces;
using CakeShop.Infrastructure;
using CakeShop.Infrastructure.EF;
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
        private IUnitofWork _unitofwork;
        public GetProductWithCategoryQueryHandler(IUnitofWork unitofWork)
        {
            _unitofwork = unitofWork;
        }
        public async Task<IEnumerable<Product>> Handle(GetProductWithCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _unitofwork.ProductRepository.GetProductListWithCategory(request.Cate_id);
        }
    }
}
