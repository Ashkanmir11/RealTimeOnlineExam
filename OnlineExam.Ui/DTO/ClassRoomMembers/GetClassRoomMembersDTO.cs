using OnlineExam.Ui.DTO.Account;

namespace OnlineExam.Ui.DTO.ClassRoomMembers
{
    public class GetClassRoomMembersDTO
    {
        public string? className { get; set; }
        public List<StudentsInfoDTO>? students { get; set; }
    }
}
