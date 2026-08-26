using System.Text.Json.Serialization;

namespace OnlineExam.Application.DTOs.Objection
{
    public class CreateObjectionDTO
    {
        public string? StudentText { get; set; }
        //Relations
        [JsonIgnore]
        public string? StudentId { get; set; }
        public int ExamId { get; set; }
    }
}
