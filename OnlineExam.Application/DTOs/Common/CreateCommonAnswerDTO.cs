using System.Text.Json.Serialization;

namespace OnlineExam.Application.DTOs.Common
{
    public class CreateCommonAnswerDTO
    {
        [JsonIgnore]
        public string? StudentId { get; set; }
        public int ExamId { get; set; }

        [JsonIgnore]
        public decimal StudentScore { get; set; } = 0;

    }
}
