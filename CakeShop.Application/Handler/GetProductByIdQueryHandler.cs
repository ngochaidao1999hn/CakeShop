using CakeShop.Application.Query;
using CakeShop.Domain.Entities;
using CakeShop.Domain.Interfaces;
using CakeShop.Dtos.ProductDto;
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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailPageDto>
    {
        private IUnitofWork _unitofwork;
        public GetProductByIdQueryHandler(IUnitofWork unitofWork)
        {
            _unitofwork = unitofWork;
        }
        public Task<ProductDetailPageDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
          return _unitofwork.ProductRepository.GetProductDetailwithSimilarProduct(request.Id);
        }
    }
}
