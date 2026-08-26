using OnlineExam.Domain.Common;

namespace OnlineExam.Domain.Entities
{
    public class DescriptiveAnswers : CommonQuestionAnswerModel
    {
        public string? StudentAnswer { get; set; }

        //Relations
        public int DescriptiveQuestionId { get; set; }
        public DescriptiveQuestion? DescriptiveQuestion { get; set; }
    }
}
