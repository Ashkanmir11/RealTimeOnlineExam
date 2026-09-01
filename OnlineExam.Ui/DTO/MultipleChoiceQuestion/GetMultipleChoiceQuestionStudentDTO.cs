using OnlineExam.Ui.DTO.Common;

namespace OnlineExam.Ui.DTO.MultipleChoiceQuestion
{
    public class GetMultipleChoiceQuestionStudentDTO : BaseDTO
    {
        public List<string>? Choices { get; set; }

    }
}
