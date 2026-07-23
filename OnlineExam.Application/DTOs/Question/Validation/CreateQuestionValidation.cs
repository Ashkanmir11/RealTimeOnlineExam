using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Question.Validation
{
    public class CreateQuestionValidation : AbstractValidator<CreateQuestionDTO>
    {
        private readonly IExamRepository _examRepository;

        public CreateQuestionValidation(IExamRepository examRepository)
        {
            _examRepository = examRepository;
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"آزمون با آیدی {Model.ExamId} یافت نشد.");
            RuleFor(e => e.QuestionText).NotEmpty().WithMessage("متن سوال نباید خالی باشد.");
            RuleFor(e => e.TotalScore).GreaterThan(0).WithMessage("نمره باید بیشتر از 0 باشد").PrecisionScale(5,2,true).WithMessage("نمره بیش از حد مجاز است.");
            RuleFor(e => e.MultipleChoiceQuestion).Must((Model, MultipleChoiceQuestion) =>
            {
                if (MultipleChoiceQuestion != null && Model.DescriptiveQuestion != null)
                {
                    return false;
                }
                if (MultipleChoiceQuestion != null && Model.TrueOrFalseQuestion != null)
                {
                    return false;
                }
                if (Model.TrueOrFalseQuestion != null && Model.DescriptiveQuestion != null)
                {
                    return false;
                }
                return true;
            }).WithMessage("سوال باید فقط یک نوع داشته باشد.");
            
        }
    }
}
