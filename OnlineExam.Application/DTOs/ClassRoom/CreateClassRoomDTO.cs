using System.Text.Json.Serialization;

namespace OnlineExam.Application.DTOs.ClassRoom
{
    public class CreateClassRoomDTO
    {
        public string? ClassName { get; set; }

        [JsonIgnore]
        public string? TeacherId { get; set; }
    }
}
