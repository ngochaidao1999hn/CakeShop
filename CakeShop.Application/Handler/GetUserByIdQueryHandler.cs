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
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private IUnitofWork _unitofwork;
        public GetUserByIdQueryHandler(IUnitofWork unitofWork) {
            _unitofwork = unitofWork;
        }
        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _unitofwork.UserRepository.GetById(request.Id);
        }
    }
}
