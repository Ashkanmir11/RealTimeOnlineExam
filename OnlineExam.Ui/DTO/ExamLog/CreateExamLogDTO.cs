using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Ui.DTO.ExamLog
{
    public class CreateExamLogDTO
    {
        public string? LogDescription { get; set; }

        public int ExamId { get; set; }
        public int LogTypeId { get; set; }
    }
}
