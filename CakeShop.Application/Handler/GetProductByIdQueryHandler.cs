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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private IProductRepository _productrepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository) {
            _productrepository = productRepository;
        }
        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
          return _productrepository.GetById<int>(request.Id);
        }
    }
}
