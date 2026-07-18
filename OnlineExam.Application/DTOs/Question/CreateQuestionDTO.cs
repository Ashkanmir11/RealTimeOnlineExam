using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Enums;
namespace OnlineExam.Application.DTOs.Question
{
    public class CreateQuestionDTO
    {
        public string? QuestionText { get; set; }
        public int? TotalScore { get; set; }
        public int QuestionNumber { get; set; }
        public int ExamId { get; set; }
        [JsonIgnore]
        public int? TrueOrFalseQuestionId { get; set; }
        [JsonIgnore]
        public int? DescriptiveQuestionId { get; set; }
        [JsonIgnore]
        public int? MultipleChoiceQuestionId { get; set; }

        public CreateTrueOrFalseQuestionDTO? TrueOrFalseQuestion { get; set; }
        public CreateDescriptiveQuestionDTO? DescriptiveQuestion { get; set; }
        public CreateMultipleChoiceQuestionDTO? MultipleChoiceQuestion { get; set; }

    }
}
