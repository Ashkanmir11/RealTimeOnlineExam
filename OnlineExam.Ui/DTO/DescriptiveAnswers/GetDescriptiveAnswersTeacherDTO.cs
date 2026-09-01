
using OnlineExam.Ui.DTO.Common;

namespace OnlineExam.Ui.DTO.DescriptiveAnswers
{
    public class GetDescriptiveAnswersTeacherDTO : BaseDTO
    {
        public string? StudentAnswer { get; set; }
        public decimal StudentScore { get; set; }

    }
}
