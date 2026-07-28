using FluentValidation;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.DescriptiveAnswers.Validation
{
    public class UpdateDescriptiveAnswersValidation : AbstractValidator<UpdateDescriptiveAnswersDTO>
    {
        private readonly IExamRepository _examRepository;
        public UpdateDescriptiveAnswersValidation(IExamRepository examRepository)
        {
            _examRepository = examRepository;
            RuleFor(e => e.StudentAnswer).MaximumLength(1000).WithMessage("پاسخ نباید بیشتر از 1000 کاراکتر باشد.");
           
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"آزمونی با آیدی {Model.ExamId} یافت نشد.");
        }

    }
}
