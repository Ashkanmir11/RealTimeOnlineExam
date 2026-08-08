using OnlineExam.Ui.DTO.Exam;
using OnlineExam.Ui.EndPoints;
using OnlineExam.Ui.Options;
using OnlineExam.Ui.Response;
using System.Net.Http.Json;
using System.Net.WebSockets;
namespace OnlineExam.Ui.Services
{
    public class ExamServices
    {
        private readonly RequestServices _requestServices;
        public ExamServices(RequestServices requestServices)
        {
            _requestServices = requestServices;
        }
        public async Task<CommonResponse<EmptyResponse>> AddExamAsync(CreateExamDTO createExamDTO)
        {
            var apiUrl = ApiRoutes.CreateExam;
            var content=JsonContent.Create(createExamDTO);
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                GetData = false,
                Content = content,
                HttpMethods = HttpMethod.Post,
                IncludeCredentials = true,
                RequiresAuth = true
            };
            return await _requestServices.SendAsync<EmptyResponse>(options);
        }

    }
}
