using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers
{
    public class GetMultipleChoiceAnswerStudentDTO : BaseDTO
    {
        public int? StudentChoice { get; set; }
    }
}
