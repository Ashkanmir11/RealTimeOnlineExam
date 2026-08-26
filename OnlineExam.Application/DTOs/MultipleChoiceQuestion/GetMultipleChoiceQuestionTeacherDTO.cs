using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Application.DTOs.MultipleChoiceQuestion
{
    public class GetMultipleChoiceQuestionTeacherDTO : BaseDTO
    {
        public List<string>? Choices { get; set; }
        public int CorrectChoice { get; set; }

    }
}
