using OnlineExam.Ui.DTO.ClassRoom;
using OnlineExam.Ui.DTO.Common;
using OnlineExam.Ui.EndPoints;
using OnlineExam.Ui.Options;
using OnlineExam.Ui.Response;
using System.Net.Http.Json;

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
        public async Task<CommonResponse<PaginateResponse<GetClassRoomTeacherDTO>>> GetMyClassAsTeacher(PaginateRequestDTO paginateRequestDTO)
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
            var result = await _requestServices.SendAsync<PaginateResponse<GetClassRoomTeacherDTO>>(options);
            return result;
        }
    }
}
