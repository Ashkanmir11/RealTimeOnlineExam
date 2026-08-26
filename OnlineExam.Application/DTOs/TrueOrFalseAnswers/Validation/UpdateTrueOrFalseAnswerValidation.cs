using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;

namespace OnlineExam.Application.DTOs.TrueOrFalseAnswers.Validation
{
    public class UpdateTrueOrFalseAnswerValidation : AbstractValidator<UpdateTrueOrFalseAnswerDTO>
    {
        private readonly IExamRepository _examRepository;
        public UpdateTrueOrFalseAnswerValidation(IExamRepository examRepository)
        {
            _examRepository = examRepository;
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"آزمونی با آیدی {Model.ExamId} یافت نشد.");
        }
    }
}
