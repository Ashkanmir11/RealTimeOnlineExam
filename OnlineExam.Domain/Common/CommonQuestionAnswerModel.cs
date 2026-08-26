namespace OnlineExam.Domain.Common
{
    public class CommonQuestionAnswerModel : BaseModel
    {
        public string? StudentId { get; set; }
        public decimal StudentScore { get; set; } = 0;
    }
}
