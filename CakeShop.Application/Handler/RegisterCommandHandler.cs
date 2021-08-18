using CakeShop.Application.Command;
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
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        private IUserRepository _userRepository;
        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return _userRepository.Register(request.registerinfo);
        }
    }
}
