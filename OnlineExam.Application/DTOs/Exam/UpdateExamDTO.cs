namespace OnlineExam.Application.DTOs.Exam
{
    public class UpdateExamDTO
    {
        public int QuestionCount { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int AllowedDelay { get; set; }
        public bool AllowedCopy { get; set; } = false;

        public bool LogStudent { get; set; } = true;
        public bool RandomQuestions { get; set; } = false;
    }
}
