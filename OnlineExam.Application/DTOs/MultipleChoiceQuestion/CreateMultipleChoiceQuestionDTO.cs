using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.MultipleChoiceQuestion
{
    public class CreateMultipleChoiceQuestionDTO
    {
        public string? QuestionText { get; set; }
        public int? TotalScore { get; set; }
        public int ExamId { get; set; }
        public List<string>? Choices { get; set; }
        public int CorrectChoice { get; set; }
        [JsonIgnore]
        public int QuestionNumber { get; set; }

    }
}
