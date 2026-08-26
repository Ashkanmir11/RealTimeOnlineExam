using OnlineExam.Domain.Common;

namespace OnlineExam.Identity.Model
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
