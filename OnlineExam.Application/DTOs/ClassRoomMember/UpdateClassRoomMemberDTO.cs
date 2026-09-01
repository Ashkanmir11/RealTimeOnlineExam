using System.Text.Json.Serialization;

namespace OnlineExam.Application.DTOs.ClassRoomMember
{
    public class UpdateClassRoomMemberDTO
    {
        public int ClasRoomId { get; set; }
        public List<string>? Phones { get; set; }

        [JsonIgnore]
        public List<string>? StudentIDs { get; set; }
    }
}
