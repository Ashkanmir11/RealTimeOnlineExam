using FluentValidation;

namespace OnlineExam.Application.DTOs.LogType.Validation
{
    public class CreateLogTypeValidation : AbstractValidator<CreateLogTypeDTO>
    {
        public CreateLogTypeValidation()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("نام نوع لاگ نباید خالی باشد.").MaximumLength(100).WithMessage("نام نوع لاگ نباید بیشتر از 100 کاراکتر باشد");
        }
    }
}
