using CakeShop.Domain.Entities;
using CakeShop.Domain.Interfaces;
using CakeShop.Infrastructure.EF;
using CakeShop.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Infrastructure
{
    public class UnitofWork : IUnitofWork, IDisposable
    {
        private bool disposedValue;
        private CakeShopDbContext _context;
        public IProductRepository ProductRepository { get; }

        public ICategoryRepository CategoryRepository { get; }
        public IUserRepository UserRepository { get; }
        public UnitofWork(CakeShopDbContext context,IProductRepository productRepository,ICategoryRepository categoryRepository,IUserRepository userRepository) {
            _context = context;
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
            UserRepository = userRepository;
        } 
       

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
