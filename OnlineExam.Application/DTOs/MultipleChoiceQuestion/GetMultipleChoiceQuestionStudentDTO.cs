using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Application.DTOs.MultipleChoiceQuestion
{
    public class GetMultipleChoiceQuestionStudentDTO : BaseDTO
    {
        public List<string>? Choices { get; set; }

    }
}
