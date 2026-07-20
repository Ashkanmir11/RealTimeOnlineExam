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
        private readonly IExamRepository _examRepository;

        public CreateDescriptiveAnswersValidation(IAccountRepository accountRepository, IDescriptiveQuestionRepository descriptiveQuestionRepository,IExamRepository examRepository)
        {
            _accountRepository = accountRepository;
            _examRepository=examRepository;
            _descriptiveQuestionRepository = descriptiveQuestionRepository;
            RuleFor(e => e.StudentAnswer).MaximumLength(1000).WithMessage("پاسخ نباید بیشتر از 1000 کاراکتر باشد.");
            RuleFor(e => e.StudentId).MustAsync(async (Id, Token) =>
            {
                return await _accountRepository.UserExistAsync(Id);
            }).WithMessage((Model)=>$"کاربری با آیدی {Model.StudentId} یافت نشد.");
            RuleFor(e => e.DescriptiveQuestionId).MustAsync(async (Id, Token) =>
            {
                return await _descriptiveQuestionRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"سوالی با آیدی {Model.DescriptiveQuestionId} یافت نشد.");
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model)=>$"آزمون با آیدی {Model.ExamId} یافت نشد.");
        }
    }
}
