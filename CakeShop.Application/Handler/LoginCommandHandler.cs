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
        private IUnitofWork _unitofWork;
        public LoginCommandHandler(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
           return _unitofWork.UserRepository.Authenticate(request.logininfo);
            
        }
    }
}
