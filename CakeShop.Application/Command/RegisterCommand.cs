using CakeShop.Domain.Viewmodels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Application.Command
{
    public class RegisterCommand:IRequest<bool>
    {
        public RegisterInfo registerinfo { get; set; }
        public RegisterCommand(RegisterInfo info) {
            registerinfo = info;
        }
    }
}
