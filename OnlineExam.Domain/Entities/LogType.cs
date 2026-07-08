using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class LogType : BaseModel
    {
        public string? Name {  get; set; }

        //Relation
        public List<ExamLog>? examLogs { get; set; }

    }
}
