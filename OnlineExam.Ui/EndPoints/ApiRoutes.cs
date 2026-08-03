namespace OnlineExam.Ui.EndPoints
{
    public class ApiRoutes
    {
        public const string ApiVersion = "1";
        public const string ApiUrl = $"http://localhost/ExamApi/api/v{ApiVersion}";

        public const string Login = $"{ApiUrl}/auth/login";
        public const string myInfo = $"{ApiUrl}/accounts/me";
        public const string RefreshToken = $"{ApiUrl}/auth/refresh-token";
        public const string Logout=$"{ApiUrl}/auth/logout";
        public const string Register = $"{ApiUrl}/auth/register";
    }
}
