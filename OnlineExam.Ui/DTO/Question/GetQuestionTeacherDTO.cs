using OnlineExam.Ui.DTO.Common;
using OnlineExam.Ui.DTO.DescriptiveQuestion;
using OnlineExam.Ui.DTO.MultipleChoiceQuestion;
using OnlineExam.Ui.DTO.TrueOrFalseQuestion;

namespace OnlineExam.Ui.DTO.Question
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
