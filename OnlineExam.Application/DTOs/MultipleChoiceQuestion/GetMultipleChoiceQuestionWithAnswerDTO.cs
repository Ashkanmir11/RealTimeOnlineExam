using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;

namespace OnlineExam.Application.DTOs.MultipleChoiceQuestion
{
    public class GetMultipleChoiceQuestionWithAnswerDTO : BaseDTO
    {
        public List<string>? Choices { get; set; }
        public int CorrectChoice { get; set; }
        public GetMultipleChoiceAnswerTeacherDTO? Answer { get; set; }
    }
}
