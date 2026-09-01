using OnlineExam.Domain.Common;

namespace OnlineExam.Domain.Entities
{
    public class ExamAttampt : BaseModel
    {
        public string? StudentId { get; set; }
        public int ExamId { get; set; }
        public bool IsEnded { get; set; } = false;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Exam? Exam { get; set; }
    }
}
