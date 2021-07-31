using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Domain.Interfaces
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
