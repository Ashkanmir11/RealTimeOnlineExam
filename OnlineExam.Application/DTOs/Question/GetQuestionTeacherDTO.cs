using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Question
{
    public class GetQuestionTeacherDTO : BaseDTO
    {
        public string? QuestionText { get; set; }
        public decimal TotalScore { get; set; }
        public GetTrueOrFalseQuestionTeacherDTO? TrueOrFalseQuestion { get; set; }
        public GetDescriptiveQuestionTeacherDTO? DescriptiveQuestion { get; set; }
        public GetMultipleChoiceQuestionTeacherDTO? MultipleChoiceQuestion { get; set; }
    }
}
