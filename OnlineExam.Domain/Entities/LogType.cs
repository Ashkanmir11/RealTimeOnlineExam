using OnlineExam.Domain.Common;

namespace OnlineExam.Domain.Entities
{
    public class LogType : BaseModel
    {
        public string? Name { get; set; }

        //Relation
        public List<ExamLog>? examLogs { get; set; }

    }
}
