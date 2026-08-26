namespace OnlineExam.Application.DTOs.Identity
{
    public class GetTokens
    {
        public string? RefreshToken { get; set; }
        public string? AccessToken { get; set; }
    }
}
