using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers
{
    public class CreateMultipleChoiceAnswerDTO : CreateCommonAnswerDTO
    {
        public int? StudentChoice { get; set; }
        public int MultipleChoiceQuestionId { get; set; }
    }
}
