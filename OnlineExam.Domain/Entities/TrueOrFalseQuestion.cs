using OnlineExam.Domain.Common;

namespace OnlineExam.Domain.Entities
{
    public class TrueOrFalseQuestion : BaseModel
    {
        public bool CorrectAnswer { get; set; }

        //Relations
        public List<TrueOrFalseAnswers>? Answers { get; set; }
        public List<Question>? Question { get; set; }

    }
}
