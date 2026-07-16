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
        private readonly IDescriptiveAnswersRepository _DescriptiveAnswersRepository;
        public UpdateDescriptiveAnswersValidation(IDescriptiveAnswersRepository DescriptiveAnswersRepository)
        {
            _DescriptiveAnswersRepository = DescriptiveAnswersRepository;
            RuleFor(e => e.StudentAnswer).MaximumLength(1000).WithMessage("پاسخ نباید بیشتر از 1000 کاراکتر باشد.");
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _DescriptiveAnswersRepository.ExistAsync(Id);
            }).WithMessage((Model)=>$"پاسخ سوال با آیدی {Model.Id} یافت نشد.");
        }

    }
}
