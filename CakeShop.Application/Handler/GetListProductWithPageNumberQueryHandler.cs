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
    public class GetListProductWithPageNumberQueryHandler : IRequestHandler<GetListProductWithPageNumberQuery, IEnumerable<Product>>
    {
        private IUnitofWork _unitofWork;
        public GetListProductWithPageNumberQueryHandler(IUnitofWork unitofWork) {
            _unitofWork = unitofWork;
        }
        public Task<IEnumerable<Product>> Handle(GetListProductWithPageNumberQuery request, CancellationToken cancellationToken)
        {
            return _unitofWork.ProductRepository.GetProductWithPage(request.Page);
        }
    }
}
