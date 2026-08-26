using System.Text.Json.Serialization;

namespace OnlineExam.Application.DTOs.ClassRoomMember
{
    public class CreateClassRoomMemberDTO
    {
        public List<string>? Phones { get; set; }
        [JsonIgnore]
        public List<string>? StudentIDs { get; set; }

        public int ClassRomeId { get; set; }
    }
}
