using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Identity
{
    public class LoginDTO
    {
        public string? Email {  get; set; }
        public string? Password { get; set; }
    }
}
