using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;

namespace OnlineExam.Application.DTOs.TrueOrFalseQuestion
{
    public class GetTrueOrFalseQuestionWithAnswerDTO : BaseDTO
    {
        public bool CorrectAnswer { get; set; }
        public GetTrueOrFalseAnswerTeacherDTO? Answer { get; set; }
    }
}
