namespace OnlineExam.Application.DTOs.MultipleChoiceQuestion
{
    public class UpdateMultipleChoiceQuestionDTO
    {
        public int Id { get; set; }
        public List<string>? Choices { get; set; }
        public int CorrectChoice { get; set; }
    }
}
