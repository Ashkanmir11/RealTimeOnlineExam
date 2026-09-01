using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Application.DTOs.DescriptiveAnswers
{
    public class GetDescriptiveAnswersTeacherDTO : BaseDTO
    {
        public string? StudentAnswer { get; set; }
        public decimal StudentScore { get; set; }

    }
}
