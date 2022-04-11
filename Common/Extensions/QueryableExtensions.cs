namespace Common.Extensions
{
    static class QueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IOrderedQueryable<T> query, int page = 1, int pageSize = 10)
        {
            //@TO-DO refactor + use this somewhere !!!
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}