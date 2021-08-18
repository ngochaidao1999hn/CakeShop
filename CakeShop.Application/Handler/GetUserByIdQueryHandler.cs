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
        private IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _userRepository.GetByGuid(request.Id);
        }
    }
}
