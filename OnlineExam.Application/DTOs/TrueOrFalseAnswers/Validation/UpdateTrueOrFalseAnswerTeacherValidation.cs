using FluentValidation;

namespace OnlineExam.Application.DTOs.TrueOrFalseAnswers.Validation
{
    public class UpdateTrueOrFalseAnswerTeacherValidation : AbstractValidator<UpdateTrueOrFalseAnswerTeacherDTO>
    {
        public UpdateTrueOrFalseAnswerTeacherValidation()
        {
            RuleFor(e => e.StudentScore).PrecisionScale(5, 2, true).WithMessage("نمره بیش از حد مجاز است.");
        }
    }
}
