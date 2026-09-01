using OnlineExam.Ui.DTO.Common;

namespace OnlineExam.Ui.DTO.MultipleChoiceQuestion
{
    public class GetMultipleChoiceQuestionTeacherDTO : BaseDTO
    {
        public List<string>? Choices { get; set; }
        public int CorrectChoice { get; set; }

    }
}
