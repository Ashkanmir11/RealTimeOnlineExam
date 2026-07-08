using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Identities
{
    public class RefreshToken : IdentityBaseModel
    {
        public string? Token { get; set; }
        public DateTime? ExpireDate { get; set; }


        //Relation
        public string? UserId { get; set; }
        public OnlineExamUser? User { get; set; }
    }
}
