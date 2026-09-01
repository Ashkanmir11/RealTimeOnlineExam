using OnlineExam.Ui.DTO.Common;

namespace OnlineExam.Ui.DTO.TrueOrFalseAnswers
{
    public class GetTrueOrFalseAnswerTeacherDTO : BaseDTO
    {
        public bool StudentAnswer { get; set; }
        public decimal StudentScore { get; set; } = 0;

    }
}
