using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.Identity;

namespace OnlineExam.Application.DTOs.ClassRoomMember
{
    public class GetClassRoomMemberDTO
    {
        public List<UserNameAndLastNameDTO>? Students { get; set; }
        public GetClassRoomDTO? GetClassRoomDTO { get; set; }
    }
}
