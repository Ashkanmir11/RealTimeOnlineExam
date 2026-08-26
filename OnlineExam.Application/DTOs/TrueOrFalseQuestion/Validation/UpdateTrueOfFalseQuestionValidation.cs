using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;

namespace OnlineExam.Application.DTOs.TrueOrFalseQuestion.Validation
{
    public class UpdateTrueOfFalseQuestionValidation : AbstractValidator<UpdateTrueOfFalseQuestionDTO>
    {
        private readonly ITrueOrFalseQuestionRepository _trueOrFalseQuestionRepository;
        public UpdateTrueOfFalseQuestionValidation(ITrueOrFalseQuestionRepository trueOrFalseQuestionRepository)
        {
            _trueOrFalseQuestionRepository = trueOrFalseQuestionRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _trueOrFalseQuestionRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"سوالی با آیدی {Model.Id} یافت نشد.");
        }
    }
}
