﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Models.PagedRequestModels;
using Common.Models.PagedRequestModels.Enums;
using Entity.Models;
using Entity.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace Entity.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<TDto>> CreatePaginatedResultAsync<TEntity, TDto>(this IQueryable<TEntity> query, PagedRequest pagedRequest, IMapper mapper)
           where TEntity : IEntityBase
           where TDto : class
        {
            query = query.ApplyFilters(pagedRequest);

            var total = await query.CountAsync();

            query = query.Sort(pagedRequest);

            query = query.Paginate(pagedRequest);

            var projectionResult = query.ProjectTo<TDto>(mapper.ConfigurationProvider);

            var listResult = await projectionResult.ToListAsync();

            return new PaginatedResult<TDto>()
            {
                Items = listResult,
                PageSize = pagedRequest.PageSize,
                PageIndex = pagedRequest.PageIndex,
                Total = total
            };
        }

        private static IQueryable<T> Paginate<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            var entities = query.Skip((pagedRequest.PageIndex - 1) * pagedRequest.PageSize).Take(pagedRequest.PageSize);
            return entities;
        }

        private static IQueryable<T> Sort<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            if (!string.IsNullOrWhiteSpace(pagedRequest.ColumnNameForSorting))
            {
                query = query.OrderBy(pagedRequest.ColumnNameForSorting + " " + pagedRequest.SortDirection);
            }
            return query;
        }

        private static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            var predicate = new StringBuilder();
            var requestFilters = pagedRequest.RequestFilters;
            for (int i = 0; i < requestFilters.Filters.Count; i++)
            {
                if (i > 0)
                {
                    predicate.Append($" {requestFilters.LogicalOperators} ");
                }

                switch (requestFilters.Filters[i].Operator)
                {
                    case FilterOperators.Contains:
                        {
                            predicate.Append(requestFilters.Filters[i].Path + $".ToLower().{nameof(string.Contains)}(@{i}.ToLower())");
                            break;
                        }
                    case FilterOperators.Equals:
                        {
                            predicate.Append(requestFilters.Filters[i].Path + $".{nameof(string.Equals)}(@{i})");
                            break;
                        }
                    case FilterOperators.EqualsNumber:
                        {
                            predicate.Append(requestFilters.Filters[i].Path + $" = (@{i})");
                            break;
                        }
                    case FilterOperators.NotEqualsNumber:
                        {
                            predicate.Append(requestFilters.Filters[i].Path + $" != (@{i})");
                            break;
                        }
                    case FilterOperators.Custom:
                        {
                            predicate.Append(requestFilters.Filters[i].Path);
                            break;
                        }
                }
            }

            if (requestFilters.Filters.Any())
            {
                var propertyValues = requestFilters.Filters.Select(filter => filter.Value).ToArray();

                query = query.Where(predicate.ToString(), propertyValues);
            }

            return query;
        }
    }
}