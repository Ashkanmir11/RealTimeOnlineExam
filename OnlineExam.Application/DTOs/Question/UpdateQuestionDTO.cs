using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Question
{
    public class UpdateQuestionDTO : BaseDTO
    {
        public string? QuestionText { get; set; }
        public int? TotalScore { get; set; }
        public CreateTrueOrFalseQuestionDTO? TrueOrFalseQuestion { get; set; }
        public CreateDescriptiveQuestionDTO? DescriptiveQuestion { get; set; }
        public CreateMultipleChoiceQuestionDTO? MultipleChoiceQuestion { get; set; }
    }
}
