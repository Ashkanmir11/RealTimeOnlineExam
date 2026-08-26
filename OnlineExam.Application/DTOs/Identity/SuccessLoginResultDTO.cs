namespace OnlineExam.Application.DTOs.Identity
{
    public class SuccessLoginResultDTO
    {
        public GetUserDTO? User { get; set; }
        public string? RefreshToken { get; set; }
        public string? AccessToken { get; set; }
    }
}
