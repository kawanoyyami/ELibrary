﻿using Common.Exceptions;
using Common.Models.PagedRequestModels;
using Entity.Models;
using Entity.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity.Extensions;
using AutoMapper;

namespace Entity.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntityBase
    {
        public readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public Repository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var entityToDeleteFromdb = await GetByIdAsync(id);
            _context.Set<TEntity>().Remove(entityToDeleteFromdb);
            await SaveChangesAsync();
        }
        public async Task<TEntity> GetByIdWithIncludeAsync(long id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> entities = _context.Set<TEntity>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    entities = entities.Include(include);
                }
            }

            return await entities.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }
        public async Task<TEntity> GetByIdAsync(long id) => await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

        public IQueryable<TEntity> Read() => _context.Set<TEntity>();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await SaveChangesAsync();
        }
        public async Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : EntityBase
                                                                                                    where TDto : class
        {
            return await _context.Set<TEntity>().CreatePaginatedResultAsync<TEntity, TDto>(pagedRequest, _mapper);
        }
        public async Task<User> GetByUserName(string username) => await _context.Set<User>().FirstOrDefaultAsync(x => x.UserName == username);

        public async Task<List<TEntity>> ListAsync() => await _context.Set<TEntity>().ToListAsync();
    }
}
