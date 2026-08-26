using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using System.Text.Json.Serialization;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers
{
    public class GetMultipleChoiceAnswerDTO : BaseDTO
    {
        public int? StudentChoice { get; set; }
        [JsonIgnore]
        public string? StudentId { get; set; }
        public GetUserDTO? User { get; set; }
        public decimal StudentScore { get; set; }
        public GetMultipleChoiceQuestionDTO? MultipleChoiceQuestion { get; set; }
    }
}
