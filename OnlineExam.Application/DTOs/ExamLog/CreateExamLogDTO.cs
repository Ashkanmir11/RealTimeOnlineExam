using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.ExamLog
{
    public class CreateExamLogDTO
    {
        public string? LogDescription { get; set; }

        public int ExamId { get; set; }
        public int LogTypeId { get; set; }
        [JsonIgnore]
        public string? StudentId {  get; set; }

    }
}
