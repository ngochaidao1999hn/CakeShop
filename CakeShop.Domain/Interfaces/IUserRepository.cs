using CakeShop.Domain.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<string> Authenticate(LoginInfo logininfo);
        Task<bool> Register(RegisterInfo registerinfo);
    }
}
