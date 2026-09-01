using OnlineExam.Ui.DTO.ClassRoomMembers;
using OnlineExam.Ui.EndPoints;
using OnlineExam.Ui.Options;
using OnlineExam.Ui.Response;
using System.Net.Http.Json;

namespace OnlineExam.Ui.Services
{
    public class ClassRoomMemberServices
    {
        private readonly RequestServices _requestServices;
        public ClassRoomMemberServices(RequestServices requestServices)
        {
            _requestServices = requestServices;
        }
        public async Task<CommonResponse<GetClassRoomMembersDTO>> GetClassStudnets(int classId)
        {
            var apiUrl = ApiRoutes.GetClassRoomMember(classId);
            var options = new RequestOptions()
            {
                ApiUrl = apiUrl,
                GetData = true,
                HttpMethods = HttpMethod.Get,
                IncludeCredentials = true,
                RequiresAuth = true,
            };
            var result = await _requestServices.SendAsync<GetClassRoomMembersDTO>(options);
            return result;
        }
        public async Task<CommonResponse<EmptyResponse>> CreateClassStudent(CreateClassRoomMemberDTO createClassRoomMemberDTO)
        {
            var apiUrl = ApiRoutes.CreateClassRoomMember;
            var content = JsonContent.Create(createClassRoomMemberDTO);
            var option = new RequestOptions()
            {
                ApiUrl = apiUrl,
                Content = content,
                GetData = false,
                HttpMethods = HttpMethod.Post,
                IncludeCredentials = true,
                RequiresAuth = true,
            };
            var result = await _requestServices.SendAsync<EmptyResponse>(option);
            return result;
        }
        public async Task<CommonResponse<EmptyResponse>> DeleteMember(string StudentId, int ClassId)
        {
            var apiUrl = ApiRoutes.DeleteClassRoomMember(StudentId, ClassId);
            var option = new RequestOptions()
            {
                ApiUrl = apiUrl,
                GetData = false,
                HttpMethods = HttpMethod.Delete,
                IncludeCredentials = true,
                RequiresAuth = true,
            };
            var result = await _requestServices.SendAsync<EmptyResponse>(option);
            return result;
        }
    }
}
