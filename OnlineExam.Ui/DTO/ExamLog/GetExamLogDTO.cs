using OnlineExam.Ui.DTO.LogType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Ui.DTO.ExamLog
{
    public class GetExamLogDTO 
    {
        public int Id { get; set; }
        public string? LogDescription { get; set; }
        public GetLogTypeDTO? LogType { get; set; }
    }
}
