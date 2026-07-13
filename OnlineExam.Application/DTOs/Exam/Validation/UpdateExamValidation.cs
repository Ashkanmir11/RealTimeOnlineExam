using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Exam.Validation
{
    public class UpdateExamValidation : AbstractValidator<UpdateExamDTO>
    {
        private readonly IExamRepository _examRepository;

        public UpdateExamValidation(IExamRepository examRepository)
        {
            _examRepository = examRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model)=>$"آزمون با آیدی {Model.Id} یافت نشد.");
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
            }).WithMessage("تاریخ شروع نباید قبل از تاریخ الان باشد.");
            //RuleFor(e => e.AllowedDelay).GreaterThan(DateTimeOffset.Now);
        }
    }
}
