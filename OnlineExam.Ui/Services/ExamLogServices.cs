using OnlineExam.Ui.DTO.ExamLog;
using OnlineExam.Ui.EndPoints;
using OnlineExam.Ui.Helper;
using OnlineExam.Ui.Options;
using OnlineExam.Ui.Response;
using System.Net.Http.Json;

namespace OnlineExam.Ui.Services
{
    public class ExamLogServices
    {
        private readonly RequestServices _requestServices;
        public ExamLogServices(RequestServices requestServices)
        {
             _requestServices = requestServices;
        }
        //logtype 1=leaving page;
        //logtype 2=trying copy and pase
        public async Task<CommonResponse<EmptyResponse>> LeavePageLog(int examId)
        {
            var apiUrl = ApiRoutes.CreateLog;
            var shamsiDate = DateHelper.MiladiToShamsi(DateTime.Now);
            var data = new CreateExamLogDTO()
            {
                ExamId = examId,
                LogTypeId = 1,
                LogDescription = $"خروج از صفحه در تاریخ و ساعت {shamsiDate} "
            };
            var content = JsonContent.Create(data);
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
        public async Task<CommonResponse<EmptyResponse>> CopyAndPaseLog(int examId)
        {
            var apiUrl = ApiRoutes.CreateLog;
            var shamsiDate = DateHelper.MiladiToShamsi(DateTime.Now);
            var data = new CreateExamLogDTO()
            {
                ExamId = examId,
                LogTypeId = 2,
                LogDescription = $"تلاش برای کپی و پیست  {shamsiDate} "
            };
            var content = JsonContent.Create(data);
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
