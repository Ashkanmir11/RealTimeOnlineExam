using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;

namespace OnlineExam.Application.DTOs.MultipleChoiceQuestion.Validation
{
    public class UpdateMultipleChoiceQuestionValidation : AbstractValidator<UpdateMultipleChoiceQuestionDTO>
    {
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;
        public UpdateMultipleChoiceQuestionValidation(IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository)
        {
            _multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;

            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _multipleChoiceQuestionRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"سوالی با آیدی {Model.Id} یافت نشد.");
            RuleFor(e => e.CorrectChoice).Must((Model, CorrectChoice) =>
            {
                if (Model.Choices.Count < CorrectChoice || CorrectChoice <= 0)
                {
                    return false;
                }
                return true;
            }).WithMessage($"پاسخ صحیح باید بین گزینه ها باشد.");
            RuleFor(e => e.Choices).Must(Model =>
            {
                if (Model.Count <= 0)
                {
                    return false;
                }
                return true;
            }).WithMessage((Model) => $"انتخاب ها نباید خالی باشند.");
        }
    }
}
