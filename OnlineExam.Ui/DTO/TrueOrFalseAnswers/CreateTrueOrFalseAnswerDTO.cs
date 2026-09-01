namespace OnlineExam.Ui.DTO.TrueOrFalseAnswers
{
    public class CreateTrueOrFalseAnswerDTO
    {
        public int ExamId { get; set; }
        public bool StudentAnswer { get; set; }
        public int TrueOrFalseQuestionId { get; set; }
    }
}
