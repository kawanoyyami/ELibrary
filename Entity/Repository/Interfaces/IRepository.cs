using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public interface IRepository<TEntity>: IDisposable
    {
        IEnumerable<TEntity> GetEntityList();
        Task<TEntity> GetEntity(long id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Save();
    }
}
