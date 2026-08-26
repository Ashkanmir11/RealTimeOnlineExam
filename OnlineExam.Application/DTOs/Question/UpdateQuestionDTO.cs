using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using System.Text.Json.Serialization;

namespace OnlineExam.Application.DTOs.Question
{
    public class UpdateQuestionDTO
    {
        public string? QuestionText { get; set; }
        public decimal? TotalScore { get; set; }
        [JsonIgnore]
        public int? TrueOrFalseQuestionId { get; set; }
        [JsonIgnore]
        public int? DescriptiveQuestionId { get; set; }
        [JsonIgnore]
        public int? MultipleChoiceQuestionId { get; set; }
        public CreateTrueOrFalseQuestionDTO? TrueOrFalseQuestion { get; set; }
        public CreateDescriptiveQuestionDTO? DescriptiveQuestion { get; set; }
        public CreateMultipleChoiceQuestionDTO? MultipleChoiceQuestion { get; set; }
    }
}
