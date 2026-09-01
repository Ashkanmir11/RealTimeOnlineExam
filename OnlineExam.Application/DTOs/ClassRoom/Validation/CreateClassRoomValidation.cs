using FluentValidation;
using OnlineExam.Application.Contracts.Identity;

namespace OnlineExam.Application.DTOs.ClassRoom.Validation
{
    public class CreateClassRoomValidation : AbstractValidator<CreateClassRoomDTO>
    {

        private readonly IAccountRepository _accountRepository;

        public CreateClassRoomValidation(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

            RuleFor(e => e.ClassName).NotEmpty().WithMessage("نام کلاس نباید خالی باشد.").MaximumLength(150).WithMessage("نام کلاس نباید بیشتر از 150 کاراکتر باشد.");
            RuleFor(e => e.TeacherId).NotEmpty().WithMessage("استاد نباید خالی باشد.").MustAsync(async (id, token) =>
            {
                var userExist = await _accountRepository.UserExistAsync(id);
                return userExist;


            }).WithMessage("استاد یافت نشد.");
        }
    }
}
