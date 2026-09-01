using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Application.DTOs.DescriptiveAnswers
{
    public class CreateDescriptiveAnswersDTO : CreateCommonAnswerDTO
    {
        public string? StudentAnswer { get; set; }
        public int DescriptiveQuestionId { get; set; }
    }
}
