using OnlineExam.Ui.DTO.Common;

namespace OnlineExam.Ui.DTO.MultipleChoiceAnswers
{
    public class GetMultipleChoiceAnswerTeacherDTO : BaseDTO
    {
        public int? StudentChoice { get; set; }
        public decimal StudentScore { get; set; } = 0;

    }
}
