using OnlineExam.Ui.DTO.MultipleChoiceAnswers;

namespace OnlineExam.Ui.DTO.MultipleChoiceQuestion
{
    public class GetMultipleChoiceQuestionWithAnswerDTO
    {
        public List<string>? Choices { get; set; }
        public int CorrectChoice { get; set; }

        public GetMultipleChoiceAnswerTeacherDTO? Answer { get; set; }
    }
}
