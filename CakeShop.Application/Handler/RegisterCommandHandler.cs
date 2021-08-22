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
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private IUnitofWork _unitofwork;
        public RegisterCommandHandler(IUnitofWork unitofWork)
        {
            _unitofwork = unitofWork;
        }
        public Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return _unitofwork.UserRepository.Register(request.registerinfo);
        }
    }
}
