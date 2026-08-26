using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using System.Text.Json.Serialization;

namespace OnlineExam.Application.DTOs.TrueOrFalseAnswers
{
    public class GetTrueOrFalseAnswerDTO : BaseDTO
    {
        [JsonIgnore]
        public string? StudentId { get; set; }
        public GetUserDTO? User { get; set; }
        public bool StudentAnswer { get; set; }
        public decimal StudentScore { get; set; }
        public GetTrueOrFalseQuestionDTO? TrueOrFalseQuestion { get; set; }
    }
}
