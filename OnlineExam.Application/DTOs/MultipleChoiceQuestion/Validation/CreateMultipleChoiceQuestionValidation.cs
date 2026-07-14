using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.MultipleChoiceQuestion.Validation
{
    public class CreateMultipleChoiceQuestionValidation : AbstractValidator<CreateMultipleChoiceQuestionDTO>
    {
        private readonly IExamRepository _examRepository;

        public CreateMultipleChoiceQuestionValidation(IExamRepository examRepository)
        {
            _examRepository = examRepository;

            RuleFor(e => e.Choices).Must(Model =>
            {
                if (Model.Count <= 0)
                {
                    return false;
                }
                return true;
            }).WithMessage((Model) => $"انتخاب ها نباید خالی باشند.");
            RuleFor(e => e.CorrectChoice).Must((Model, CorrectChoice) =>
            {
                if(Model.Choices.Count< CorrectChoice || CorrectChoice<=0)
                {
                    return false;
                }
                return true;
            }).WithMessage($"پاسخ صحیح باید بین گزینه ها باشد.");
            RuleFor(e => e.QuestionText).NotEmpty().WithMessage("متن سوال نباید خالی باشد.");
            RuleFor(e => e.TotalScore).GreaterThan(0).WithMessage("نمره باید بیشتر از 0 باشد");
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"آزمون با آیدی {Model.ExamId} یافت نشد.");
        }
    }
}
