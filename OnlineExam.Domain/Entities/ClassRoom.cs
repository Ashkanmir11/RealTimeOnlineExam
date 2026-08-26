using OnlineExam.Domain.Common;

namespace OnlineExam.Domain.Entities
{
    public class ClassRoom : BaseModel
    {
        public string? ClassName { get; set; }

        //Relations
        public string? TeacherId { get; set; }
        public List<Exam>? Exams { get; set; }
        //public List<OnlineExamUser>? Students { get; set; }
        //public OnlineExamUser? Teacher { get; set; }
    }
}
