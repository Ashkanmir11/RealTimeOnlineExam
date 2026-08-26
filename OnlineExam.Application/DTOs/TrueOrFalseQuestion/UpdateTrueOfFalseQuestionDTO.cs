using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Application.DTOs.TrueOrFalseQuestion
{
    public class UpdateTrueOfFalseQuestionDTO : BaseDTO
    {
        public bool CorrectAnswer { get; set; }
    }
}
