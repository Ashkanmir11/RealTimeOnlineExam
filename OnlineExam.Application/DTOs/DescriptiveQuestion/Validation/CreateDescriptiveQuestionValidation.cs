using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.DescriptiveQuestion.Validation
{
    public class CreateDescriptiveQuestionValidation : AbstractValidator<CreateDescriptiveQuestionDTO>
    {
        private readonly IExamRepository _examRepository;
        public CreateDescriptiveQuestionValidation(IExamRepository examRepository)
        {
            _examRepository = examRepository;
            RuleFor(e => e.CorrectAnswer).MaximumLength(1000).WithMessage("پاسخ درست نباید بیشتر از 1000 کاراکتر باشد.");
            RuleFor(e => e.QuestionText).NotEmpty().WithMessage("متن سوال نباید خالی باشد.");
            RuleFor(e => e.TotalScore).GreaterThan(0).WithMessage("نمره باید بیشتر از 0 باشد");
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
              return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model)=>$"آزمون با آیدی {Model.ExamId} یافت نشد.");
        }
    }
}
