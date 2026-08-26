using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Application.DTOs.TrueOrFalseAnswers
{
    public class CreateTrueOrFalseAnswerDTO : CreateCommonAnswerDTO
    {
        public bool StudentAnswer { get; set; }
        public int TrueOrFalseQuestionId { get; set; }
    }
}
