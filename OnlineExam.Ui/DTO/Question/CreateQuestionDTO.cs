using OnlineExam.Ui.DTO.DescriptiveQuestion;
using OnlineExam.Ui.DTO.MultipleChoiceQuestion;
using OnlineExam.Ui.DTO.TrueOrFalseQuestion;

namespace OnlineExam.Ui.DTO.Question
{
    public class CreateQuestionDTO
    {
        public string? QuestionText { get; set; }
        public decimal? TotalScore { get; set; }
        public int ExamId { get; set; }
        public CreateTrueOrFalseQuestionDTO? TrueOrFalseQuestion { get; set; }
        public CreateDescriptiveQuestionDTO? DescriptiveQuestion { get; set; }
        public CreateMultipleChoiceQuestionDTO? MultipleChoiceQuestion { get; set; }
    }
}
