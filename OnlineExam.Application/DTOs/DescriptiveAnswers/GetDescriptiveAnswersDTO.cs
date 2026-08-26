using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.DTOs.Identity;
using System.Text.Json.Serialization;

namespace OnlineExam.Application.DTOs.DescriptiveAnswers
{
    public class GetDescriptiveAnswersDTO : BaseDTO
    {
        public string? StudentAnswer { get; set; }
        public GetUserDTO? UserDTO { get; set; }

        [JsonIgnore]
        public string? StudentId { get; set; }
        public decimal StudentScore { get; set; }
        public GetDescriptiveQuestionDTO? DescriptiveQuestion { get; set; }
    }
}
