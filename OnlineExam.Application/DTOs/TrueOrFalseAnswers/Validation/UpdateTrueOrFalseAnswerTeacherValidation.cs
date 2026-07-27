using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.TrueOrFalseAnswers.Validation
{
    public class UpdateTrueOrFalseAnswerTeacherValidation : AbstractValidator<UpdateTrueOrFalseAnswerTeacherDTO>
    {
        private readonly ITrueOrFalseAnswersRepository _trueOrFalseAnswersRepository;
        private readonly IQuestionRepository _questionRepository;
        public UpdateTrueOrFalseAnswerTeacherValidation(ITrueOrFalseAnswersRepository trueOrFalseAnswersRepository
            , IQuestionRepository questionRepository
              )
        {
            _trueOrFalseAnswersRepository = trueOrFalseAnswersRepository;
            _questionRepository = questionRepository;

            RuleFor(e => e.StudentScore).PrecisionScale(5, 2, true).WithMessage("نمره بیش از حد مجاز است.");
        }
    }
}
