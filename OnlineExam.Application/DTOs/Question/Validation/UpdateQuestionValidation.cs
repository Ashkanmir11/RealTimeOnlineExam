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
        public UpdateQuestionValidation()
        {
            RuleFor(e => e.QuestionText).NotEmpty().WithMessage("متن سوال نباید خالی باشد.");
            RuleFor(e => e.TotalScore).GreaterThan(0).WithMessage("نمره باید بیشتر از 0 باشد").PrecisionScale(5,2,true).WithMessage("نمره بیش از حد مجار است.");
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
