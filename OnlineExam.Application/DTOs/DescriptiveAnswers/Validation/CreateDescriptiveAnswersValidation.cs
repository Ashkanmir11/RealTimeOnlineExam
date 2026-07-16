using FluentValidation;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.DescriptiveAnswers.Validation
{
    public class CreateDescriptiveAnswersValidation : AbstractValidator<CreateDescriptiveAnswersDTO>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IDescriptiveQuestionRepository _descriptiveQuestionRepository;

        public CreateDescriptiveAnswersValidation(IAccountRepository accountRepository, IDescriptiveQuestionRepository descriptiveQuestionRepository)
        {
            _accountRepository = accountRepository;
            _descriptiveQuestionRepository = descriptiveQuestionRepository;
            RuleFor(e => e.StudentAnswer).MaximumLength(1000).WithMessage("پاسخ نباید بیشتر از 1000 کاراکتر باشد.");
            RuleFor(e => e.StudentId).MustAsync(async (Id, Token) =>
            {
                return await _accountRepository.UserExistAsync(Id);
            }).WithMessage((Model)=>$"کاربری با آیدی {Model.StudentId} یافت نشد.");
            RuleFor(e => e.DescriptiveAnswersId).MustAsync(async (Id, Token) =>
            {
                return await _descriptiveQuestionRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"سوالی با آیدی {Model.DescriptiveAnswersId} یافت نشد.");
        }
    }
}
