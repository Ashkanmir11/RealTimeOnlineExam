namespace OnlineExam.Ui.DTO.MultipleChoiceQuestion
{
    public class CreateMultipleChoiceQuestionDTO
    {
        public List<string>? Choices { get; set; }
        public int CorrectChoice { get; set; }

    }
}
