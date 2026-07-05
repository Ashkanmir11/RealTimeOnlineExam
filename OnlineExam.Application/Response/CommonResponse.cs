using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Response
{
    public class CommonResponse<T>
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string>? Errors { get; set; }
        public T? Data {  get; set; }
    }
}
