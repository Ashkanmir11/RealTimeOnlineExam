using FluentValidation;

namespace OnlineExam.Application.DTOs.DescriptiveAnswers.Validation
{
    public class UpdateDescriptiveAnswersTeacherValidation : AbstractValidator<UpdateDescriptiveAnswersTeacherDTO>
    {
        public UpdateDescriptiveAnswersTeacherValidation()
        {
            RuleFor(e => e.StudentScore).PrecisionScale(5, 2, true).WithMessage("نمره بیش از حد مجاز است.");
        }
    }
}
