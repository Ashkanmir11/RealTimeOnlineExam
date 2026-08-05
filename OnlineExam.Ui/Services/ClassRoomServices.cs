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
            var apiUrl = ApiRoutes.GetClassRoomAsTeacher(paginateRequestDTO);
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
        public async Task<CommonResponse<EmptyResponse>> DeleteAsync(int id)
        {
            var apiUrl = ApiRoutes.DeleteClassRoom(id);
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                RequiresAuth = true,
                GetData = false,
                HttpMethods = HttpMethod.Delete,
                IncludeCredentials = true,
            };
            var result = await _requestServices.SendAsync<EmptyResponse>(options);
            return result;
        }
        public async Task<CommonResponse<GetClassRoomTeacherDTO>> GetByIdAsync(int id)
        {
            var apiUrl = ApiRoutes.GetClassRoomById(id);
            var optins = new RequestOptions()
            {
                ApiUrl = apiUrl,
                HttpMethods = HttpMethod.Get,
                IncludeCredentials = true,
                GetData = true,
                RequiresAuth = true,
            };
            var result = await _requestServices.SendAsync<GetClassRoomTeacherDTO>(optins);
            return result;
        }
        public async Task<CommonResponse<EmptyResponse>> UpdateAsync(int id, UpdateClassRoomDTO dto)
        {
            var apiUrl = ApiRoutes.UpdateClassRoom(id);
            var content = JsonContent.Create(new
            {
                ClassName = dto.ClassName,
            });
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                HttpMethods = HttpMethod.Put,
                IncludeCredentials = true,
                Content = content,
                GetData = false,
                RequiresAuth = true,
            };
            var result = await _requestServices.SendAsync<EmptyResponse>(options);
            return result;
        }
    }
}
