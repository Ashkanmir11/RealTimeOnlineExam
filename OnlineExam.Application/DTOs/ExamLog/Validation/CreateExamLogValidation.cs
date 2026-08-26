using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;

namespace OnlineExam.Application.DTOs.ExamLog.Validation
{
    public class CreateExamLogValidation : AbstractValidator<CreateExamLogDTO>
    {
        private readonly IExamRepository _examRepository;
        private readonly ILogTypeRepository _logTypeRepository;
        public CreateExamLogValidation(IExamRepository examRepository, ILogTypeRepository logTypeRepository)
        {
            _examRepository = examRepository;
            _logTypeRepository = logTypeRepository;
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"آزمونی با ایدی {Model.ExamId} یافت نشد.");
            RuleFor(e => e.LogTypeId).MustAsync(async (Id, Token) =>
            {
                return await _logTypeRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"نوع لاگی با ایدی {Model.ExamId} یافت نشد.");
            RuleFor(e => e.LogDescription).MaximumLength(500).WithMessage("توضیحات نباید بیشتر از 500 کاراکتر باشد.");
        }
    }
}
