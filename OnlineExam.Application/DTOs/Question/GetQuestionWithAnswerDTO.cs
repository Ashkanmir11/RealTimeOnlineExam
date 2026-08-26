using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;

namespace OnlineExam.Application.DTOs.Question
{
    public class GetQuestionWithAnswerDTO : BaseDTO
    {
        public string? QuestionText { get; set; }
        public decimal TotalScore { get; set; }
        public GetTrueOrFalseQuestionTeacherDTO? TrueOrFalseQuestion { get; set; }
        public GetDescriptiveQuestionWithAnswerDTO? DescriptiveQuestion { get; set; }
        public GetMultipleChoiceQuestionWithAnswerDTO? MultipleChoiceQuestion { get; set; }
    }
}
