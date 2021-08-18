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
    public class GetListProductWithPageNumberQueryHandler : IRequestHandler<GetListProductWithPageNumberQuery, IEnumerable<Product>>
    {
        private IProductRepository _productrepository;
        public GetListProductWithPageNumberQueryHandler(IProductRepository productRepository) {
            _productrepository = productRepository;
        }
        public Task<IEnumerable<Product>> Handle(GetListProductWithPageNumberQuery request, CancellationToken cancellationToken)
        {
            return _productrepository.GetProductWithPage(request.Page);
        }
    }
}
