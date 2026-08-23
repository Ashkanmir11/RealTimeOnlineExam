using OnlineExam.Application.DTO.DescriptiveAnswers;

namespace OnlineExam.Ui.DTO.DescriptiveQuestion
{
    public class GetDescriptiveQuestionWithAnswerDTO
    {
        public string? CorrectAnswer { get; set; }
        public GetDescriptiveAnswersTeacherDTO? Answer { get; set; }
    }
}
