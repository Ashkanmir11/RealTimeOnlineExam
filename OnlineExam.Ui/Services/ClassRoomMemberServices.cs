using OnlineExam.Ui.DTO.ClassRoomMembers;
using OnlineExam.Ui.EndPoints;
using OnlineExam.Ui.Options;
using OnlineExam.Ui.Response;

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
            var result=await _requestServices.SendAsync<GetClassRoomMembersDTO>(options);
            return result;
        }
    }
}
