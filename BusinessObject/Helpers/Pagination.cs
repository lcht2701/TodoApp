using System.Linq.Dynamic.Core;
using X.PagedList;

namespace BusinessObject.Helpers
{
    public static class Pagination
    {
        public static IPagedList<T> ApplyPagination<T>(this IQueryable<T> data, int page, int pageSize, string? filterOrder, string? sortOrder)
        {
            //Apply Filter
            data = ApplyFilter(data, filterOrder);
            // Apply sorting
            data = ApplySorting(data, sortOrder);

            if (pageSize == -1)
            {
                return data.ToPagedList(page, data.Count());
            }

            // Apply paging
            return data.ToPagedList(page, pageSize);
        }

        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, string? filter)
        {
            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = query.Where(filter);
            }

            return query;
        }


        private static IQueryable<T> ApplySorting<T>(IQueryable<T> data, string? sortOrder)
        {
            if (!string.IsNullOrWhiteSpace(sortOrder))
            {
                data = data.OrderBy(sortOrder); // Use the dynamic sorting expression
            }

            return data;
        }
    }
}
