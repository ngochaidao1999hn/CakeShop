using CakeShop.Domain.Viewmodels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Application.Command
{
    public class LoginCommand:IRequest<string>
    {
       public LoginInfo logininfo { get; set; }
        public LoginCommand(LoginInfo info) {
            logininfo = info;
        }
    }
}
