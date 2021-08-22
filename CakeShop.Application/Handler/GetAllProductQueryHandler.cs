using CakeShop.Application.Query;
using CakeShop.Domain.Entities;
using CakeShop.Domain.Interfaces;
using CakeShop.Infrastructure;
using CakeShop.Infrastructure.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CakeShop.Application.Handler
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private IUnitofWork _unitofwork ;
        public GetAllProductQueryHandler(IUnitofWork unitofWork) {
            _unitofwork = unitofWork;
        }
        public  Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return _unitofwork.ProductRepository.GetAll();
        }
    }
}
