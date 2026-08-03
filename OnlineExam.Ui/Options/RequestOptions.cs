using System.Net.Http.Json;

namespace OnlineExam.Ui.Options
{
    public class RequestOptions
    {
        public required HttpMethod? HttpMethods { get; set; }
        public required string? ApiUrl { get; set; }

        public JsonContent? Content { get; set; } = null;
        public bool IncludeCredentials { get; set; } = false;
        public bool RequiresAuth { get; set; } = true;
    }
}
