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
        public static PaginateResponse<T> Paginate(List<T> data, int totalCount, PaginateRequestDTO paginateRequestDTO)
        {
            int TotalPage = totalCount % paginateRequestDTO.PageCount == 0 ? totalCount / paginateRequestDTO.PageCount : (totalCount / paginateRequestDTO.PageCount) + 1;

            var result = new PaginateResponse<T>()
            {
                PageCount = paginateRequestDTO.PageCount,
                TotalCount = totalCount,
                TotalPage = TotalPage,
                PageNumber = paginateRequestDTO.PageNumber,
                Data = data

            };
            return result;
        }
    }
}
