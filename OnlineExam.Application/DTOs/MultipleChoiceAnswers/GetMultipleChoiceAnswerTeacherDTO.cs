using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers
{
    public class GetMultipleChoiceAnswerTeacherDTO : BaseDTO
    {
        public int? StudentChoice { get; set; }
        public decimal StudentScore { get; set; } = 0;

    }
}
