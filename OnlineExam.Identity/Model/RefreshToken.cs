using OnlineExam.Application.DTOs.Identity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Identity.Model
{
    public class RefreshToken : IdentityBaseDTO
    {
        public string? Token {  get; set; }
        public DateTime? ExpireDate { get; set; }


        //Relation
        public string? UserId {  get; set; }
        public OnlineExamUser? User { get; set; }
    }
}
