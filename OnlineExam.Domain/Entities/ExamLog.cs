using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class ExamLog : BaseModel
    {
        public string? LogDescription {  get; set; }
        //Relation

        public int ExamId {  get; set; }
        public Exam? Exam { get; set; }
        public int LogTypeId {  get; set; }
        public LogType? LogType { get; set; }

        //public int StudentId {  get; set; }
        //public OnlineExamUser? User { get; set; }
    }
}
