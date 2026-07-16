using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers.Validation
{
    public class UpdateMultipleChoiceAnswerValidation : AbstractValidator<UpdateMultipleChoiceAnswerDTO>
    {
        private readonly IMultipleChoiceAnswersRepository _MultipleChoiceAnswersRepository;
        public UpdateMultipleChoiceAnswerValidation(IMultipleChoiceAnswersRepository MultipleChoiceAnswersRepository)
        {
            _MultipleChoiceAnswersRepository = MultipleChoiceAnswersRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _MultipleChoiceAnswersRepository.ExistAsync(Id);
            }).WithMessage((Model)=>$"پاسخی با آیدی {Model.Id} یافت نشد.");

        }
    }
}
