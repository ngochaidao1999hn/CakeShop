using CakeShop.Application.Command;
using CakeShop.Application.Query;
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
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private IUserRepository _userRepository;
        public LoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
           return _userRepository.Authenticate(request.logininfo);
            
        }
    }
}
