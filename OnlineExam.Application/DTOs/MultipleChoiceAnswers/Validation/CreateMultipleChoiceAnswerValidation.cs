using FluentValidation;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers.Validation
{
    public class CreateMultipleChoiceAnswerValidation:AbstractValidator<CreateMultipleChoiceAnswerDTO>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;
        private readonly IExamRepository _examRepository;
        
        public CreateMultipleChoiceAnswerValidation(IAccountRepository accountRepository, IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository,IExamRepository examRepository)
        {
            _accountRepository = accountRepository;
            _multipleChoiceQuestionRepository= multipleChoiceQuestionRepository;
            _examRepository = examRepository;
            RuleFor(e => e.StudentId).MustAsync(async (Id, Token) =>
            {
                return await _accountRepository.UserExistAsync(Id);
            }).WithMessage((Model) => $"کاربر با آیدی {Model.StudentId} یافت نشد.");
            RuleFor(e => e.MultipleChoiceQuestionId).MustAsync(async (Id, Token) =>
            {
                return await _multipleChoiceQuestionRepository.ExistAsync(Id);
            }).WithMessage((Model)=>$"سوالی با آیدی {Model.MultipleChoiceQuestionId} یافت نشد.");
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"آزمون با آیدی {Model.ExamId} یافت نشد.");
        }
    }
}
