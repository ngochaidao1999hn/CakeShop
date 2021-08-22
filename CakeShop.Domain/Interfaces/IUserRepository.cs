using CakeShop.Domain.Entities;
using CakeShop.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Domain.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        Task<string> Authenticate(LoginInfo logininfo);
        Task<string> Register(RegisterInfo registerinfo);    
    }
}
