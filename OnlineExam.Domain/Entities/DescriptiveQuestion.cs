using OnlineExam.Domain.Common;

namespace OnlineExam.Domain.Entities
{
    public class DescriptiveQuestion : BaseModel
    {
        public string? CorrectAnswer { get; set; }

        //Relation
        public List<DescriptiveAnswers>? Answers { get; set; }
        public List<Question>? Question { get; set; }
    }
}
