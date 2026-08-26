using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;


namespace OnlineExam.Application.DTOs.Question
{
    public class GetQuestionStudentDTO : BaseDTO
    {
        public string? QuestionText { get; set; }
        public decimal TotalScore { get; set; }
        public GetTrueOrFalseQuestionStudentDTO? TrueOrFalseQuestion { get; set; }
        public GetDescriptiveQuestionStudentDTO? DescriptiveQuestion { get; set; }
        public GetMultipleChoiceQuestionStudentDTO? MultipleChoiceQuestion { get; set; }
    }
}
