using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Objection.Validation
{
    public class CreateObjectionValidation : AbstractValidator<CreateObjectionDTO>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IExamRepository _examRepository;
        public CreateObjectionValidation(IAccountRepository accountRepository, IExamRepository examRepository)
        {
            _accountRepository = accountRepository;
            _examRepository = examRepository;
            RuleFor(e => e.Comment).MaximumLength(1000).WithMessage("متن اعتراض نباید بیشتر از 1000 کاراکتر باشد.");
            RuleFor(e => e.StudentId).MustAsync(async (Id, Token) =>
            {
                var userExist = await _accountRepository.UserExistAsync(Id);
                return userExist;
            }).WithMessage("دانش آموز یافت نشد.");
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                var examExist = await _examRepository.ExistAsync(Id);
                return examExist;
            }).WithMessage("کلاس یافت نشد.");
        }
    }
}
