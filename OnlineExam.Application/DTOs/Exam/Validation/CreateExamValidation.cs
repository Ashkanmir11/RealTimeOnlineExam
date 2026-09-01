using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;

namespace OnlineExam.Application.DTOs.Exam.Validation
{
    public class CreateExamValidation : AbstractValidator<CreateExamDTO>
    {
        private readonly IClassRoomRepository _classRoomRepository;

        public CreateExamValidation(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
            RuleFor(e => e.QuestionCount).GreaterThan(0).WithMessage("تعداد سوال باید بیشتر از 0 باشد.");
            RuleFor(e => e.Name).NotEmpty().WithMessage("نام آزمون نباید خالی باشد.").MaximumLength(150).WithMessage("نام آزمون نباید بیشتر از 150 کاراکتر باشد");
            RuleFor(e => e.Description).MaximumLength(500).WithMessage("توضیحات آزمون نباید بیشتر از 500 کاراکتر باشد.");
            RuleFor(e => e.StartDate).LessThan(e => e.EndDate).WithMessage("تاریخ شروع نباید بعد از تاریخ پایان باشد.").Must((model, date) =>
                {
                    if (DateTime.Now > model.StartDate)
                    {
                        return false;
                    }
                    return true;
                }).WithMessage("تاریخ شروع نباید قبل از تاریخ الان باشد.").Must((Model, date) =>
                {
                    date = date.Value.AddMinutes(5);
                    if (date > Model.EndDate)
                    {
                        return false;
                    }
                    return true;
                }).WithMessage("زمان آزمون باید بیشتر از 5 دقیقه باشد.");
            RuleFor(e => e.AllowedDelay).GreaterThanOrEqualTo(1).WithMessage("زمان مجاز تاخیر باید 1 یا بیشتر باشد.").Must((Model, Delay) =>
            {
                var totalWithDelay = Model.StartDate.Value.AddMinutes(Delay);
                if (totalWithDelay > Model.EndDate)
                {
                    return false;
                }
                return true;
            }).WithMessage("میزان زمان مجاز تاخیر نباید بیشتر از ساعت پایان باشد.");

            RuleFor(e => e.ClassId).MustAsync(async (Id, Token) =>
            {
                return await _classRoomRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"کلاسی با آیدی {Model.ClassId} یافت نشد.");

        }

    }
}
