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
        private readonly IExamRepository _examRepository;
        public UpdateTrueOrFalseAnswerValidation(ITrueOrFalseAnswersRepository trueOrFalseAnswersRepository, IExamRepository examRepository)
        {
            _TrueOrFalseAnswersRepository = trueOrFalseAnswersRepository;
            _examRepository = examRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _TrueOrFalseAnswersRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"پاسخی با آیدی {Model.Id} یافت نشد.");
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"آزمونی با آیدی {Model.ExamId} یافت نشد.");
        }
    }
}
