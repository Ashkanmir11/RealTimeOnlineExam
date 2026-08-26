using System.Text.Json.Serialization;

namespace OnlineExam.Application.DTOs.Identity
{
    public class RegisterDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [JsonIgnore]
        public string? UserName { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? PhoneNumber { get; set; }
        public int NationCode { get; set; }
    }
}
