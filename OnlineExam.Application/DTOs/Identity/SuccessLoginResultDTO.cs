using OnlineExam.Application.DTOs.Identity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Identity
{
    public class SuccessLoginResultDTO 
    {
        public GetUserDTO? User {  get; set; }
        public string? RefreshToken {  get; set; }
        public string? AccessToken {  get; set; }
    }
}
