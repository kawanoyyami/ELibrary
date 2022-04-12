using Common.Models.PagedRequestModels;
using Entity.Models;
using Entity.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntityBase
    {
        Task<TEntity> GetByIdAsync(long id);
        Task<TEntity> GetByIdWithIncludeAsync(long id, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> ListAsync();
        Task AddAsync(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(long id);
        IQueryable<TEntity> Read();
        Task<int> SaveChangesAsync();
        Task<PaginatedResult<TDto>> GetPagedData<TDto>(PagedRequest pagedRequest) where TDto : class;
    }
}
