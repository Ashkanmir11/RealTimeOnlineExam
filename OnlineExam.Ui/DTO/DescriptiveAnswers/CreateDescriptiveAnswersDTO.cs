namespace OnlineExam.Ui.DTO.DescriptiveAnswers
{
    public class CreateDescriptiveAnswersDTO
    {
        public int ExamId { get; set; }
        public string? StudentAnswer { get; set; }
        public int DescriptiveQuestionId { get; set; }
    }
}
