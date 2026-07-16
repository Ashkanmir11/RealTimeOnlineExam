using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers.Validation
{
    public class UpdateMultipleChoiceQuestionAnswerValidation : AbstractValidator<UpdateMultipleChoiceQuestionAnswerDTO>
    {
        private readonly IMultipleChoiceQuestionAnswersRepository _multipleChoiceQuestionAnswersRepository;
        public UpdateMultipleChoiceQuestionAnswerValidation(IMultipleChoiceQuestionAnswersRepository multipleChoiceQuestionAnswersRepository)
        {
            _multipleChoiceQuestionAnswersRepository = multipleChoiceQuestionAnswersRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _multipleChoiceQuestionAnswersRepository.ExistAsync(Id);
            }).WithMessage((Model)=>$"پاسخی با آیدی {Model.Id} یافت نشد.");

        }
    }
}
