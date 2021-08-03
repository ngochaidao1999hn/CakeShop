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
        private readonly UserManager<User> _usermanager;
        private readonly SignInManager<User> _signinmanager;
        private readonly RoleManager<Role> _rolemanager;
        private readonly IConfiguration _config;

        public IProductRepository productRepository { get; set; }

        public IUserRepository userRepository { get; set; }

        public UnitofWork(CakeShopDbContext context,UserManager<User>userManager,SignInManager<User>signInManager,RoleManager<Role>roleManager,IConfiguration config) {
            _context = context;
            _usermanager = userManager;
            _signinmanager = signInManager;
            _rolemanager = roleManager;
            _config = config;
            productRepository = new ProductRepository(_context);
            userRepository = new UserRepository(_usermanager,_signinmanager,_rolemanager,_config,_context);
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
