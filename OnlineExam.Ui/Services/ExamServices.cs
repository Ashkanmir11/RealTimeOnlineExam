using Newtonsoft.Json.Schema;
using OnlineExam.Ui.DTO.Common;
using OnlineExam.Ui.DTO.Exam;
using OnlineExam.Ui.DTO.Question;
using OnlineExam.Ui.DTO.TrueOrFalseAnswers;
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
            var content = JsonContent.Create(createExamDTO);
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
        public async Task<CommonResponse<PaginateResponse<GetExamDetailDTO>>> GetExamTeacher(int classId, PaginateRequestDTO paginateRequestDTO)
        {
            var apiUrl = ApiRoutes.GetExamByClassId(classId, paginateRequestDTO);
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                GetData = true,
                HttpMethods = HttpMethod.Get,
                IncludeCredentials = true,
                RequiresAuth = true
            };
            return await _requestServices.SendAsync<PaginateResponse<GetExamDetailDTO>>(options);
        }
        public async Task<CommonResponse<EmptyResponse>> DeleteAsync(int id)
        {
            var apiUrl = ApiRoutes.DeleteExam(id);
            var option = new RequestOptions()
            {
                ApiUrl = apiUrl,
                GetData = false,
                HttpMethods = HttpMethod.Delete,
                IncludeCredentials = true,
                RequiresAuth = true
            };
            return await _requestServices.SendAsync<EmptyResponse>(option);
        }
        public async Task<CommonResponse<UpdateExamDTO>> GetByIdAsync(int id)
        {
            var apiUrl = ApiRoutes.GetExamById(id);
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                GetData = true,
                HttpMethods = HttpMethod.Get,
                IncludeCredentials = true,
                RequiresAuth = true
            };
            return await _requestServices.SendAsync<UpdateExamDTO>(options);
        }
        public async Task<CommonResponse<EmptyResponse>> UpdateAsync(int id,UpdateExamDTO updateExamDTO)
        {
            var apiUrl = ApiRoutes.UpdateExam(id);
            var content = JsonContent.Create(updateExamDTO);
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                GetData = false,
                HttpMethods = HttpMethod.Put,
                IncludeCredentials = true,
                RequiresAuth = true,
                Content=content
            };
            return await _requestServices.SendAsync<EmptyResponse>(options);
        }
        public async Task<CommonResponse<PaginateResponse<GetQuestionStudentDTO>>> StartExam(int examId,PaginateRequestDTO paginateRequestDTO)
        {
            var apiUrl = ApiRoutes.StartExam(paginateRequestDTO,examId);
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                GetData = true,
                HttpMethods = HttpMethod.Post,
                IncludeCredentials = true,
                RequiresAuth = true,
            };
            return await _requestServices.SendAsync<PaginateResponse<GetQuestionStudentDTO>>(options);
        }
        public async Task<CommonResponse<GetTrueOrFalseAnswerStudentDTO>> GetMyTrueOrFalseAnswer(int questionId)
        {
            var apiUrl = ApiRoutes.GetMyTrueOrFalseAnswer(questionId);
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                GetData = true,
                HttpMethods = HttpMethod.Get,
                IncludeCredentials = true,
                RequiresAuth = true,
            };
            return await _requestServices.SendAsync<GetTrueOrFalseAnswerStudentDTO>(options);
        }
        public async Task<CommonResponse<EmptyResponse>> CreateTrueOrFalseAnswer(CreateTrueOrFalseAnswerDTO createTrueOrFalseAnswerDTO)
        {
            var apiUrl = ApiRoutes.CreateTrueOrFalseAnswer;
            var content = JsonContent.Create(createTrueOrFalseAnswerDTO);
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                GetData = false,
                Content = content,
                HttpMethods = HttpMethod.Post,
                IncludeCredentials = true,
                RequiresAuth = true,
            };
            return await _requestServices.SendAsync<EmptyResponse>(options);
        }
        public async Task<CommonResponse<EmptyResponse>> UpdateTrueOrFalseAnswer(int id,UpdateTrueOrFalseAnswerDTO updateTrueOrFalseAnswerDTO)
        {
            var apiUrl = ApiRoutes.UpdateTrueOrFalseAnswer(id);
            var content = JsonContent.Create(updateTrueOrFalseAnswerDTO);
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                GetData = false,
                Content = content,
                HttpMethods = HttpMethod.Put,
                IncludeCredentials = true,
                RequiresAuth = true
            };
            return await _requestServices.SendAsync<EmptyResponse>(options);
        }

    }
}
