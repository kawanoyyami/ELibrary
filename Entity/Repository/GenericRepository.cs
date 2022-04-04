using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public void DeleteRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().RemoveRange(entities);

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

        public void UpdateRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().RemoveRange(entities);
    }
}
