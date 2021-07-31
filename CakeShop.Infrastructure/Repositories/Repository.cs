﻿using CakeShop.Domain.Interfaces;
using CakeShop.Infrastructure.EF;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private CakeShopDbContext _context;
        private DbSet<T> DbSet;
        public Repository(CakeShopDbContext context) {
            _context = context;
            DbSet = _context.Set<T>();
        }
        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(int id)
        {
            DbSet.Remove( DbSet.Find(id));
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
