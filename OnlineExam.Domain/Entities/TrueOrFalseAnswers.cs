using OnlineExam.Domain.Common;

namespace OnlineExam.Domain.Entities
{
    public class TrueOrFalseAnswers : CommonQuestionAnswerModel
    {
        public bool StudentAnswer { get; set; }
        //Relations
        public int TrueOrFalseQuestionId { get; set; }
        public TrueOrFalseQuestion? TrueOrFalseQuestion { get; set; }

    }
}
