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
        Task<TEntity?> FindEntity(Expression<Func<TEntity, bool>> findBy, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> ListAsync();
        Task AddAsync(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(long id);
        IQueryable<TEntity> Read();
        Task<int> SaveChangesAsync();
        Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : EntityBase where TDto : class;
    }
}
