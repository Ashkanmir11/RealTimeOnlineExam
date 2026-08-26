using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Exceptions;
using System.Linq.Dynamic.Core;
namespace OnlineExam.Application.Helper
{
    public static class QuerySortHelper<T>
    {
        public static IQueryable<T> Sort(IQueryable<T> query, PaginateRequestDTO paginateRequest)
        {
            try
            {
                if (paginateRequest.SortBy == null || paginateRequest.SortBy == "")
                {
                    return query;

                }
                else
                {
                    return paginateRequest.Descending == true ? query.OrderBy(paginateRequest.SortBy + " " + "desc") : query.OrderBy(paginateRequest.SortBy);

                }
            }
            catch
            {
                throw new BadRequestException($"فیلد {paginateRequest.SortBy} وجود ندارد.");
            }
        }
    }
}
