using OnlineExam.Domain.Common;

namespace OnlineExam.Domain.Entities
{
    public class MultipleChoiceQuestion : BaseModel
    {
        public List<string>? Choices { get; set; }
        public int CorrectChoice { get; set; }

        //Relations
        public List<MultipleChoiceAnswers>? Answers { get; set; }
        public List<Question>? Question { get; set; }

    }
}
