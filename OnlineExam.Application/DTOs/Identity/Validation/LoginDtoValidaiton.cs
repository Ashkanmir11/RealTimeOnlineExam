using FluentValidation;

namespace OnlineExam.Application.DTOs.Identity.Validation
{
    public class LoginDtoValidaiton : AbstractValidator<LoginDTO>
    {
        public LoginDtoValidaiton()
        {
            RuleFor(e => e.PhoneNumber).MaximumLength(11).WithMessage("شماره تلفن باید 11 رقم باشد.").MinimumLength(11).WithMessage("شماره تلفن باید 11 رقم باشد.").NotEmpty().WithMessage("شماره موبایل نباید خالی باشد.");
            RuleFor(e => e.Password).NotEmpty().WithMessage("رمز نباید خالی باشد.");

        }
    }
}
