using OnlineExam.Domain.Common;

namespace OnlineExam.Domain.Entities
{
    public class Question : BaseModel
    {
        public string? QuestionText { get; set; }
        public decimal? TotalScore { get; set; }
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }

        public int? TrueOrFalseQuestionId { get; set; }
        public TrueOrFalseQuestion? TrueOrFalseQuestion { get; set; }
        public int? DescriptiveQuestionId { get; set; }
        public DescriptiveQuestion? DescriptiveQuestion { get; set; }
        public int? MultipleChoiceQuestionId { get; set; }
        public MultipleChoiceQuestion? MultipleChoiceQuestion { get; set; }
    }
}
