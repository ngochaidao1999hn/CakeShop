using CakeShop.Domain.Interfaces;
using CakeShop.Infrastructure.EF;
using CakeShop.Infrastructure.Repositories;
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
        

        public IProductRepository productRepository { get; set; }

        

        public UnitofWork(CakeShopDbContext context) {
            _context = context;
            productRepository = new ProductRepository(_context);
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
