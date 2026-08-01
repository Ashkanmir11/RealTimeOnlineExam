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
        private readonly IMultipleChoiceAnswersRepository _multipleChoiceAnswersRepository;
        public CreateMultipleChoiceAnswerValidation(IAccountRepository accountRepository
            , IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository,IExamRepository examRepository, IMultipleChoiceAnswersRepository multipleChoiceAnswersRepository)
        {
            _accountRepository = accountRepository;
            _multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
            _examRepository = examRepository;
            _multipleChoiceAnswersRepository = multipleChoiceAnswersRepository;


            RuleFor(e => e.StudentId).MustAsync(async (Id, Token) =>
            {
                return await _accountRepository.UserExistAsync(Id);
            }).WithMessage((Model) => $"کاربر با آیدی {Model.StudentId} یافت نشد.");
            RuleFor(e => e.StudentId).MustAsync(async (Model, Id, Token) =>
            {
                var exist = await _multipleChoiceAnswersRepository.IsAnswerExist(Id, Model.MultipleChoiceQuestionId);
                return !exist;
            }).WithMessage("پاسخ این سوال موجود است.");

            RuleFor(e => e.MultipleChoiceQuestionId).MustAsync(async (Id, Token) =>
            {
                return await _multipleChoiceQuestionRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"سوالی با آیدی {Model.MultipleChoiceQuestionId} یافت نشد.");

            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"آزمون با آیدی {Model.ExamId} یافت نشد.");
            RuleFor(e => e.StudentChoice).MustAsync(async (Model, StudentChoice, Token) =>
            {
                if (StudentChoice == null)
                {
                    return true;
                }
                var question = await _multipleChoiceQuestionRepository.GetAsync(Model.MultipleChoiceQuestionId);
                if (question == null)
                {
                    return false;
                }
                int choicec = question.Choices.Count;
                if (StudentChoice == 0 || StudentChoice > choicec)
                {
                    return false;
                }
                return true;
            }).WithMessage("گزینه انتخابی باید بین گزینه ها باشد.");
        }
    }
}
