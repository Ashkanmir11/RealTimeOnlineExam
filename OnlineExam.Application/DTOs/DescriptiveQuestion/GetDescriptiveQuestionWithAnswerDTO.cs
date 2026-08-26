using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveAnswers;

namespace OnlineExam.Application.DTOs.DescriptiveQuestion
{
    public class GetDescriptiveQuestionWithAnswerDTO : BaseDTO
    {
        public string? CorrectAnswer { get; set; }
        public GetDescriptiveAnswersTeacherDTO? Answer { get; set; }
    }
}
