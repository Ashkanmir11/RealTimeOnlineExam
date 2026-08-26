using OnlineExam.Application.DTOs.Identity;

namespace OnlineExam.Application.DTOs.ClassRoomMember
{
    public class GetClassRoomMemberTeacherDTO
    {
        public string? ClassName { get; set; }
        public List<GetUserDTO>? Students { get; set; }
    }
}
