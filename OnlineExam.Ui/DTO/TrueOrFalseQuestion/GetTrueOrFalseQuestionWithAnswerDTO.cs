using OnlineExam.Ui.DTO.TrueOrFalseAnswers;

namespace OnlineExam.Ui.DTO.TrueOrFalseQuestion
{
    public class GetTrueOrFalseQuestionWithAnswerDTO
    {
        public bool CorrectAnswer { get; set; }
        public GetTrueOrFalseAnswerTeacherDTO? Answer { get; set; }
    }
}
