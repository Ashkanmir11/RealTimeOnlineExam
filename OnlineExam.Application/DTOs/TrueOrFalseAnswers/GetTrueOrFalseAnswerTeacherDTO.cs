using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Application.DTOs.TrueOrFalseAnswers
{
    public class GetTrueOrFalseAnswerTeacherDTO : BaseDTO
    {
        public bool StudentAnswer { get; set; }
        public decimal StudentScore { get; set; } = 0;

    }
}
