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

        private readonly IMultipleChoiceAnswersRepository _multipleChoiceAnswersRepository;
        private readonly IQuestionRepository _questionRepository;

        public GetMultipleChoiceAnswerTeacherValidation(IMultipleChoiceAnswersRepository multipleChoiceAnswersRepository, IQuestionRepository questionRepository)
        {
            _multipleChoiceAnswersRepository = multipleChoiceAnswersRepository;
            _questionRepository = questionRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _multipleChoiceAnswersRepository.ExistAsync(Id);
            }).WithMessage("پاسخ یافت نشد.");
            RuleFor(e => e.StudentScore).MustAsync(async (Model, Score, Token) =>
                {
                    var question = await _questionRepository.GetByQuestionDetailIdAsync(false, true, false, Model.Id);
                    if (Score > question.TotalScore)
                    {
                        return false;
                    }
                    return true;
                }).WithMessage($"نمره درج شده از نمره آزمون نباید بزرگتر باشد.").PrecisionScale(5, 2, true).WithMessage("نمره بیش از حد مجاز است.");
        }
    }
}
