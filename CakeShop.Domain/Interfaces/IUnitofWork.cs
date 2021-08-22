using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Domain.Interfaces
{
    public interface IUnitofWork:IDisposable
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IUserRepository UserRepository { get; }
        Task Commit();
    }
}
