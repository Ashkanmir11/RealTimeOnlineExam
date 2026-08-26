namespace OnlineExam.Ui.DTO.MultipleChoiceAnswers
{
    public class CreateMultipleChoiceAnswerDTO
    {
        public int ExamId { get; set; }
        public int? StudentChoice { get; set; }
        public int MultipleChoiceQuestionId { get; set; }
    }
}
