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
        private readonly IDescriptiveAnswersRepository _descriptiveAnswersRepository;
        private readonly IQuestionRepository _questionRepository;
        public UpdateDescriptiveAnswersTeacherValidation(IDescriptiveAnswersRepository descriptiveAnswersRepository, IQuestionRepository questionRepository)
        {
            _descriptiveAnswersRepository = descriptiveAnswersRepository;
            _questionRepository = questionRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _descriptiveAnswersRepository.ExistAsync(Id);
            }).WithMessage("پاسخ یافت نشد.");

            RuleFor(e => e.StudentScore).MustAsync(async (Model, Score, Token) =>
            {
                var question = await _questionRepository.GetByQuestionDetailIdAsync(false, false, true, Model.Id);
                if(question==null)
                {
                    return false;
                }

                if (Score > question.TotalScore)
                {
                    return false;
                }
                return true;
            }).WithMessage($"نمره درج شده از نمره آزمون نباید بزرگتر باشد.").PrecisionScale(5, 2, true).WithMessage("نمره بیش از حد مجاز است.");
        }
    }
}
