using System.Text.Json.Serialization;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers
{
    public class UpdateMultipleChoiceAnswerDTO
    {
        [JsonIgnore]
        public int QuestionId { get; set; }
        public int? StudentChoice { get; set; }
        public int ExamId { get; set; }

    }
}
