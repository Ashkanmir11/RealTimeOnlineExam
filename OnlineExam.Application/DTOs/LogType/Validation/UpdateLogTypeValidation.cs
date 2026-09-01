using FluentValidation;

namespace OnlineExam.Application.DTOs.LogType.Validation
{
    public class UpdateLogTypeValidation : AbstractValidator<UpdateLogTypeDTO>
    {

        public UpdateLogTypeValidation()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("نام نوع لاگ نباید خالی باشد.")
                .MaximumLength(100).WithMessage("نام نوع لاگ نباید بیشتر از 100 کاراکتر باشد");

        }
    }
}
