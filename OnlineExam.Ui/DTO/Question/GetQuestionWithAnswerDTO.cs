using OnlineExam.Ui.DTO.DescriptiveQuestion;
using OnlineExam.Ui.DTO.MultipleChoiceQuestion;
using OnlineExam.Ui.DTO.TrueOrFalseQuestion;

namespace OnlineExam.Ui.DTO.Question
{
    public class GetQuestionWithAnswerDTO
    {
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public decimal TotalScore { get; set; }
        public GetTrueOrFalseQuestionWithAnswerDTO? TrueOrFalseQuestion { get; set; }
        public GetDescriptiveQuestionWithAnswerDTO? DescriptiveQuestion { get; set; }
        public GetMultipleChoiceQuestionWithAnswerDTO? MultipleChoiceQuestion { get; set; }
    }
}
