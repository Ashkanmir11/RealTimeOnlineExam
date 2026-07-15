using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.TrueOrFalseQuestion.Validation
{
    public class CreateTrueOrFalseQuestionValidation : AbstractValidator<CreateTrueOrFalseQuestionDTO>
    {
        private readonly IExamRepository _examRepository;
        public CreateTrueOrFalseQuestionValidation(IExamRepository examRepository)
        {
            _examRepository = examRepository;
            RuleFor(e => e.QuestionText).NotEmpty().WithMessage("متن سوال نباید خالی باشد.");
            RuleFor(e => e.TotalScore).GreaterThan(0).WithMessage("نمره باید بیشتر از 0 باشد");
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"آزمون با آیدی {Model.ExamId} یافت نشد.");
        }
    }
}
