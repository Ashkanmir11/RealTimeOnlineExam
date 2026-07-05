using OnlineExam.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Identity
{
    public class GetUserDTO : BaseDTO
    {
        public string? UserName { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
