using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Question.Validation
{
    public class UpdateQuestionValidation : AbstractValidator<UpdateQuestionDTO>
    {
        private readonly IQuestionRepository _questionRepository;
        public UpdateQuestionValidation(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _questionRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"سوالی با آیدی {Model.Id} یافت نشد.");
            RuleFor(e => e.QuestionText).NotEmpty().WithMessage("متن سوال نباید خالی باشد.");
            RuleFor(e => e.TotalScore).GreaterThan(0).WithMessage("نمره باید بیشتر از 0 باشد");
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
