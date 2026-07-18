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
        private readonly IExamRepository _examRepository;

        public UpdateMultipleChoiceAnswerValidation(IMultipleChoiceAnswersRepository MultipleChoiceAnswersRepository, IExamRepository examRepository)
        {
            _examRepository = examRepository;
            _MultipleChoiceAnswersRepository = MultipleChoiceAnswersRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _MultipleChoiceAnswersRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"پاسخی با آیدی {Model.Id} یافت نشد.");
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"آزمونی با آیدی {Model.ExamId} یافت نشد.");
        }
    }
}
