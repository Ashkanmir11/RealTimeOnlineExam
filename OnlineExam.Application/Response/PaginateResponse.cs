using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Response
{
    public class PaginateResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage {  get; set; }
        public List<T>? Data { get; set; }
    }
}
