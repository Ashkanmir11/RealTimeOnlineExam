using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;

namespace OnlineExam.Application.DTOs.DescriptiveQuestion.Validation
{
    public class UpdateDescriptiveQuestionValidation : AbstractValidator<UpdateDescriptiveQuestionDTO>
    {
        private readonly IDescriptiveQuestionRepository _descriptiveQuestionRepository;

        public UpdateDescriptiveQuestionValidation(IDescriptiveQuestionRepository descriptiveQuestionRepository)
        {
            _descriptiveQuestionRepository = descriptiveQuestionRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _descriptiveQuestionRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"سوالی با آیدی {Model.Id} یافت نشد.");
            RuleFor(e => e.CorrectAnswer).MaximumLength(1000).WithMessage("پاسخ درست نباید بیشتر از 1000 کاراکتر باشد.");

        }
    }
}
