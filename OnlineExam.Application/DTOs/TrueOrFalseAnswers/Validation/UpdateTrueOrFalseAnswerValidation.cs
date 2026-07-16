using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.TrueOrFalseAnswers.Validation
{
    public class UpdateTrueOrFalseAnswerValidation : AbstractValidator<UpdateTrueOrFalseAnswerDTO>
    {
        private readonly ITrueOrFalseAnswersRepository _TrueOrFalseAnswersRepository;
        public UpdateTrueOrFalseAnswerValidation(ITrueOrFalseAnswersRepository TrueOrFalseAnswersRepository)
        {
            _TrueOrFalseAnswersRepository = TrueOrFalseAnswersRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _TrueOrFalseAnswersRepository.ExistAsync(Id);
            }).WithMessage((Model)=>$"پاسخی با آیدی {Model.Id} یافت نشد.");
        }
    }
}
