using FluentValidation;

namespace OnlineExam.Application.DTOs.Objection.Validation
{
    public class UpdateObjectionValidation : AbstractValidator<UpdateObjectionDTO>
    {
        public UpdateObjectionValidation()
        {
            RuleFor(e => e.StudentText).MaximumLength(1000).WithMessage("متن اعتراض نباید بیشتر از 1000 کاراکتر باشد.");
            RuleFor(e => e.TeacherComment).MaximumLength(1000).WithMessage("متن اعتراض نباید بیشتر از 1000 کاراکتر باشد.");
        }
    }
}
