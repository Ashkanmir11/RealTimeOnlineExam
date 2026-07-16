using FluentValidation;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.TrueOrFalseAnswers.Validation
{
    public class CreateTrueOrFalseAnswerValidation : AbstractValidator<CreateTrueOrFalseAnswerDTO>
    {
        private readonly ITrueOrFalseQuestionRepository _trueOrFalseQuestionRepository;
        private readonly IAccountRepository _accountRepository;

        public CreateTrueOrFalseAnswerValidation(ITrueOrFalseQuestionRepository trueOrFalseQuestionRepository, IAccountRepository accountRepository)
        {
            _accountRepository=accountRepository;
            _trueOrFalseQuestionRepository = trueOrFalseQuestionRepository;
            RuleFor(e => e.StudentId).NotEmpty().WithMessage("یوزر نباید خالی باشد.").MustAsync(async(Id,Token)=>
            {
                return await _accountRepository.UserExistAsync(Id);
            }).WithMessage((Model)=>$"کاربر با آیدی {Model.StudentId} یافت نشد.");
            RuleFor(e => e.TrueOrFalseQuestionId).MustAsync(async (Id, Token) =>
            {
                return await _trueOrFalseQuestionRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"سوالی با آیدی {Model.TrueOrFalseQuestionId} یافت نشد.");
        }
    }
}
