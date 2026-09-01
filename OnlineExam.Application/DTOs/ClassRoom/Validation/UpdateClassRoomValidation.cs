using FluentValidation;

namespace OnlineExam.Application.DTOs.ClassRoom.Validation
{
    public class UpdateClassRoomValidation : AbstractValidator<UpdateClassRoomDTO>
    {

        public UpdateClassRoomValidation()
        {
            RuleFor(e => e.ClassName).NotEmpty().WithMessage("نام کلاس نباید خالی باشد.").MaximumLength(150).WithMessage("نام کلاس نباید بیشتر از 150 کاراکتر باشد.");
        }
    }
}
