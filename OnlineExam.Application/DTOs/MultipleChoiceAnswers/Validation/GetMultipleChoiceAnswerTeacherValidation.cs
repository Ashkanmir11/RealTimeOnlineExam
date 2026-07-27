using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers.Validation
{
    public class GetMultipleChoiceAnswerTeacherValidation : AbstractValidator<UpdateMultipleChoiceAnswerTeacherDTO>
    {
        private readonly IExamRepository _examRepository;

        public GetMultipleChoiceAnswerTeacherValidation(IExamRepository examRepository)
        {
            _examRepository = examRepository;
            RuleFor(e => e.StudentScore).PrecisionScale(5, 2, true).WithMessage("نمره بیش از حد مجاز است.");
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model)=>$"آزمون با آیدی  {Model.ExamId} یافت نشد.");
        }
    }
}
