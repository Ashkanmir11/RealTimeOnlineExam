using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.DTOs.LogType;
using System.Text.Json.Serialization;

namespace OnlineExam.Application.DTOs.ExamLog
{
    public class GetExamLogDTO : BaseDTO
    {
        public string? LogDescription { get; set; }

        public GetExamSummeryDTO? Exam { get; set; }
        public GetLogTypeDTO? LogType { get; set; }

        [JsonIgnore]
        public string? StudentId { get; set; }
        public GetUserDTO? Student { get; set; }
    }
}
