using OnlineExam.Domain.Common;

namespace OnlineExam.Application.DTOs.Identity
{
    public class GetUserDTO : IdentityBaseModel
    {
        public string? UserName { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
