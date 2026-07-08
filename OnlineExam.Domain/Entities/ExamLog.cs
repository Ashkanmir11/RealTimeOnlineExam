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
        public int LogTypeId {  get; set; }
        public LogType? LogType { get; set; }
    }
}
