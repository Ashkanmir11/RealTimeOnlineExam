namespace OnlineExam.Ui.DTO.ExamLog
{
    public class CreateExamLogDTO
    {
        public string? LogDescription { get; set; }

        public int ExamId { get; set; }
        public int LogTypeId { get; set; }
    }
}
