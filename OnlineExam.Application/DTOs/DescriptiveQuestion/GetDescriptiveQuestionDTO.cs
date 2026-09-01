using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Application.DTOs.DescriptiveQuestion
{
    public class GetDescriptiveQuestionDTO : BaseDTO
    {
        public string? CorrectAnswer { get; set; }
    }
}
