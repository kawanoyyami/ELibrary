using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(long id, List<string> includes = null) ;
        Task<List<TEntity>> ListAsync();
        Task AddAsync(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(long id);
        IQueryable<TEntity> Read();
        Task<int> SaveChangesAsync();

    }
}
