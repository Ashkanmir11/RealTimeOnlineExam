namespace OnlineExam.Ui.EndPoints
{
    public class ApiRoutes
    {
        public const string ApiVersion = "1";
        public const string ApiUrl = $"http://localhost/ExamApi/api/v{ApiVersion}";

        public const string Login = $"{ApiUrl}/auth/login";
    }
}
