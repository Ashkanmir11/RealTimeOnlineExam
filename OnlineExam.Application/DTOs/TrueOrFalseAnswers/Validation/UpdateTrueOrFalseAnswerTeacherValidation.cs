using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.TrueOrFalseAnswers.Validation
{
    public class UpdateTrueOrFalseAnswerTeacherValidation: AbstractValidator<UpdateTrueOrFalseAnswerTeacherDTO>
    {
        private readonly ITrueOrFalseAnswersRepository _trueOrFalseAnswersRepository;
        private readonly IQuestionRepository _questionRepository;
        public UpdateTrueOrFalseAnswerTeacherValidation(ITrueOrFalseAnswersRepository trueOrFalseAnswersRepository, IQuestionRepository questionRepository)
        {
            _trueOrFalseAnswersRepository = trueOrFalseAnswersRepository;
            _questionRepository = questionRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                return await _trueOrFalseAnswersRepository.ExistAsync(Id);
            }).WithMessage("پاسخ یافت نشد.");
            RuleFor(e => e.StudentScore).MustAsync(async (Model, Score, Token) =>
            {
                var question = await _questionRepository.GetByQuestionDetailId(true, false, false, Model.Id);
                if (Score > question.TotalScore)
                {
                    return false;
                }
                return true;
            }).WithMessage($"نمره درج شده از نمره آزمون نباید بزرگتر باشد.");
        }
    }
}
