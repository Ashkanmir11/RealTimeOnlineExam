using OnlineExam.Domain.Common;

namespace OnlineExam.Domain.Entities
{
    public class ExamLog : BaseModel
    {
        public string? LogDescription { get; set; }

        //Relation
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }
        public int LogTypeId { get; set; }
        public LogType? LogType { get; set; }

        public string? StudentId { get; set; }
    }
}
