using Common.Exceptions;
using Entity.Models;
using Entity.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntityBase
    {
        public readonly ApplicationContext _context;
        public Repository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await SaveChangesAsync();
        }
        
        public async Task Delete(long id)
        {
            var entityToDeleteFromdb = await GetByIdAsync(id);
            if (entityToDeleteFromdb == null)
            {
                throw new NotFoundException($"Entity of type {typeof(TEntity).Name} with id : {id} not found in db!");
            }
            _context.Set<TEntity>().Remove(entityToDeleteFromdb);
            await SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(long id, List<string> includes = null)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (includes != null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TEntity>> ListAsync() => await _context.Set<TEntity>().ToListAsync();

        public IQueryable<TEntity> Read() => _context.Set<TEntity>();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await SaveChangesAsync();
        }
    }
}
