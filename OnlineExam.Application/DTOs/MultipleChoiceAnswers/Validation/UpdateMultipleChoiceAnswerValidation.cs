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
        private readonly IExamRepository _examRepository;

        public UpdateMultipleChoiceAnswerValidation(IMultipleChoiceAnswersRepository MultipleChoiceAnswersRepository, IExamRepository examRepository)
        {
            _examRepository = examRepository;

            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"آزمونی با آیدی {Model.ExamId} یافت نشد.");
        }
    }
}
