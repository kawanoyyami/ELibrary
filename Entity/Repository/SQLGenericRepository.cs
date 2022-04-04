﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Entity.Repository
{
    public class SQLGenericRepository<TEntity>: IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext _context;
        private bool _disposed = false;
        public SQLGenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await Save();
        }

        public virtual void Dispose(bool disposing)
        {
            if(!this._disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<TEntity> GetEntity(long id) => await _context.Set<TEntity>().FindAsync(id);

        public IEnumerable<TEntity> GetEntityList() => _context.Set<TEntity>().ToList();

        public async Task Save() => await _context.SaveChangesAsync();

        public async Task Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}