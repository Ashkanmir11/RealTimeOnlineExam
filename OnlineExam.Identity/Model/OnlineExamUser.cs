using Microsoft.AspNetCore.Identity;

namespace OnlineExam.Identity.Model
{
    public class OnlineExamUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? NationalCode { get; set; }

        //Relations
        public List<RefreshToken>? RefreshTokens { get; set; }

    }
}
