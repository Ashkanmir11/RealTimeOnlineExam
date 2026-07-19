using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Common
{
    public class CreateCommonAnswerDTO
    {
        [JsonIgnore]
        public string? StudentId { get; set; }
        public int ExamId { get; set; }

        [JsonIgnore]
        public decimal StudentScore { get; set; } = 0;

    }
}
