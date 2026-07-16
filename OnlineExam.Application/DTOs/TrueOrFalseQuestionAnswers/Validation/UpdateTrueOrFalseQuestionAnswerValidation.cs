using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.TrueOrFalseQuestionAnswers.Validation
{
    public class UpdateTrueOrFalseQuestionAnswerValidation : AbstractValidator<UpdateTrueOrFalseQuestionAnswerDTO>
    {
        private readonly ITrueOrFalseQuestionAnswersRepository _trueOrFalseQuestionAnswersRepository;
        public UpdateTrueOrFalseQuestionAnswerValidation(ITrueOrFalseQuestionAnswersRepository trueOrFalseQuestionAnswersRepository)
        {
            _trueOrFalseQuestionAnswersRepository = trueOrFalseQuestionAnswersRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _trueOrFalseQuestionAnswersRepository.ExistAsync(Id);
            }).WithMessage((Model)=>$"پاسخی با آیدی {Model.Id} یافت نشد.");
        }
    }
}
