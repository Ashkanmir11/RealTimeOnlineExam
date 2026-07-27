using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.DescriptiveAnswers.Validation
{
    public class UpdateDescriptiveAnswersTeacherValidation : AbstractValidator<UpdateDescriptiveAnswersTeacherDTO>
    {
        public UpdateDescriptiveAnswersTeacherValidation(int score)
        {
            RuleFor(e => e.StudentScore).PrecisionScale(5, 2, true).WithMessage("نمره بیش از حد مجاز است.");
        }
    }
}
