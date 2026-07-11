using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Common
{
    public class PaginateRequestDTO
    {
        public int PageNumber { get; set; } = 1;
        public int PageCount { get; set; } = 10;
        public string? SortBy { get; set; }
        public bool Descending { get; set; } = false;
    }
}
