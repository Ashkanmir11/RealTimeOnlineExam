using OnlineExam.Ui.DTO.ClassRoom;
using OnlineExam.Ui.DTO.Common;
using OnlineExam.Ui.EndPoints;
using OnlineExam.Ui.Options;
using OnlineExam.Ui.Response;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineExam.Ui.Services
{
    public class ClassRoomServices
    {
        private readonly RequestServices _requestServices;
        public ClassRoomServices(RequestServices requestServices)
        {
            _requestServices = requestServices;
        }
        public async Task<CommonResponse<EmptyResponse>> CreateAsync(CreateClassRoomDTO createClassRoomDTO)
        {
            var apuUrl = ApiRoutes.CreateClassRoom;
            var content = JsonContent.Create(new
            {
                className = createClassRoomDTO.ClassName,
            });
            var options = new RequestOptions()
            {
                ApiUrl = apuUrl,
                GetData = false,
                Content = content,
                HttpMethods = HttpMethod.Post,
                IncludeCredentials = true,
                RequiresAuth = true,
            };
            var result = await _requestServices.SendAsync<EmptyResponse>(options);
            return result;
        }
        public async Task<CommonResponse<PaginateResponse<GetClassRoomTeacherDTO>>> GetMyClassAsTeacherAsync(PaginateRequestDTO paginateRequestDTO)
        {
            var apiUrl = ApiRoutes.GetClassRoomAsTeacher + $"PageNumber={paginateRequestDTO.PageNumber}&PageCount={paginateRequestDTO.PageCount}";
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                HttpMethods = HttpMethod.Get,
                IncludeCredentials = true,
                RequiresAuth = true,
                GetData = true,
            };
            Console.WriteLine("arrive here");
            var result = await _requestServices.SendAsync<PaginateResponse<GetClassRoomTeacherDTO>>(options);
            Console.WriteLine("exit here");
            Console.WriteLine(result.StatusCode);
            return result;
        }
        public async Task<CommonResponse<EmptyResponse>> DeleteAsync(int id)
        {
            var apiUrl = ApiRoutes.DeleteClassRoom + id;
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                RequiresAuth = true,
                GetData = false,
                HttpMethods = HttpMethod.Delete,
                IncludeCredentials = true,
            };
            var result=await _requestServices.SendAsync<EmptyResponse>(options);
            return result;
        }
    }
}
