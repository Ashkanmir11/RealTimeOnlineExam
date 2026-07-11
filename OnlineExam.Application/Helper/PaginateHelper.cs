using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Helper
{
    public static class PaginateHelper<T>
    {
        public static int GetSkip(PaginateRequestDTO paginateRequestDTO)
        {
            return (paginateRequestDTO.PageNumber - 1) * paginateRequestDTO.PageCount;
        }
        public static PaginateResponse<T> Paginate(List<T> Data, int TotalCount, int PageCount, int PageNumber)
        {
            int TotalPage = TotalCount % PageCount == 0 ? TotalCount / PageCount : (TotalCount / PageCount) + 1;

            var result = new PaginateResponse<T>()
            {
                PageCount = PageCount,
                TotalCount = TotalCount,
                TotalPage = TotalPage,
                PageNumber = PageNumber,
                Data = Data

            };
            return result;
        }
    }
}
