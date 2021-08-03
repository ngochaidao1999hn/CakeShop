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
        private IUnitofWork _unitofwork;
        public GetListProductWithPageNumberQueryHandler(IUnitofWork unitofwork) {
            _unitofwork = unitofwork;
        }
        public Task<IEnumerable<Product>> Handle(GetListProductWithPageNumberQuery request, CancellationToken cancellationToken)
        {
            return _unitofwork.productRepository.GetProductWithPage(request.Page);
        }
    }
}
