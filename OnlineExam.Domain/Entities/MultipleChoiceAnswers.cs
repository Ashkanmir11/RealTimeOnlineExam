using OnlineExam.Domain.Common;

namespace OnlineExam.Domain.Entities
{
    public class MultipleChoiceAnswers : CommonQuestionAnswerModel
    {
        public int? StudentChoice { get; set; }
        //Relations
        public int MultipleChoiceQuestionId { get; set; }
        public MultipleChoiceQuestion? MultipleChoiceQuestion { get; set; }


    }
}
