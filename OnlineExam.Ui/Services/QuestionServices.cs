using OnlineExam.Ui.DTO.Question;
using OnlineExam.Ui.EndPoints;
using OnlineExam.Ui.Options;
using OnlineExam.Ui.Response;
using System.Net.Http.Json;

namespace OnlineExam.Ui.Services
{
    public class QuestionServices
    {
        private readonly RequestServices _requestServices;
        public QuestionServices(RequestServices requestServices)
        {
            _requestServices = requestServices;
        }
        public async Task<CommonResponse<EmptyResponse>> AddAsync(CreateQuestionDTO createQuestionDTO)
        {
            var apiUrl = ApiRoutes.CreateQuestion;
            var content = JsonContent.Create(createQuestionDTO);
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                GetData = false,
                Content = content,
                HttpMethods = HttpMethod.Post,
                RequiresAuth = true,
                IncludeCredentials = true,
            };
            return await _requestServices.SendAsync<EmptyResponse>(options);

        }
    }
}
