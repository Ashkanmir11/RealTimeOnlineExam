using FluentValidation;
using OnlineExam.Application.Contracts.Identity;

namespace OnlineExam.Application.DTOs.Identity.Validation
{
    public class RegisterDtoValidation : AbstractValidator<RegisterDTO>
    {
        private readonly IAccountRepository _accountRepository;
        public RegisterDtoValidation(IAccountRepository accountRepository)
        {

            _accountRepository = accountRepository;
            RuleFor(e => e.FirstName).MinimumLength(1).WithMessage("نام بیش از حد کوچک است.").MaximumLength(150).WithMessage("نام بیش از حد بزرگ است.").NotEmpty().WithMessage("نام نباید خالی باشد.");
            RuleFor(e => e.LastName).MinimumLength(1).WithMessage("نام خانوادگی بیش از حد کوچک است.").MaximumLength(150).WithMessage("نام خانوادگی بیش از حد بزرگ است.").NotEmpty().WithMessage("نام خانوادگی نباید خالی باشد.");
            RuleFor(e => e.Password).Equal(e => e.ConfirmPassword).WithMessage("رمز عبور با تکرار رمز عبور مطابقت ندارد.");
            RuleFor(e => e.Email).EmailAddress().WithMessage("ایمیل معتبر نیست");
            RuleFor(e => e.PhoneNumber).Length(11).WithMessage("شماره تلفن باید 11 رقم باشد.").MustAsync(async (Phone, Token) =>
            {
                return !await _accountRepository.PhoneExistAsync(Phone);
            }).WithMessage((Model) => $"شماره تلفن {Model.PhoneNumber} تکراری است.");

        }
    }
}
