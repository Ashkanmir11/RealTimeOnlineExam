using FluentValidation;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers.Validation
{
    public class CreateMultipleChoiceQuestionAnswerValidation:AbstractValidator<CreateMultipleChoiceQuestionAnswerDTO>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;
        
        public CreateMultipleChoiceQuestionAnswerValidation(IAccountRepository accountRepository, IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository)
        {
            _accountRepository = accountRepository;
            _multipleChoiceQuestionRepository= multipleChoiceQuestionRepository;
            RuleFor(e => e.StudentId).MustAsync(async (Id, Token) =>
            {
                return await _accountRepository.UserExistAsync(Id);
            }).WithMessage((Model) => $"کاربر با آیدی {Model.StudentId} یافت نشد.");
            RuleFor(e => e.MultipleChoiceQuestionId).MustAsync(async (Id, Token) =>
            {
                return await _multipleChoiceQuestionRepository.ExistAsync(Id);
            }).WithMessage((Model)=>$"سوالی با آیدی {Model.MultipleChoiceQuestionId} یافت نشد.");
        }
    }
}
