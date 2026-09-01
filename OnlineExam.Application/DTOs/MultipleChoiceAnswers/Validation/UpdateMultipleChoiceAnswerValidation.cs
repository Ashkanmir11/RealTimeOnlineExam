using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers.Validation
{
    public class UpdateMultipleChoiceAnswerValidation : AbstractValidator<UpdateMultipleChoiceAnswerDTO>
    {
        private readonly IExamRepository _examRepository;
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;

        public UpdateMultipleChoiceAnswerValidation(IExamRepository examRepository, IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository)
        {
            _examRepository = examRepository;
            _multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
            RuleFor(e => e.ExamId).MustAsync(async (Id, Token) =>
            {
                return await _examRepository.ExistAsync(Id);
            }).WithMessage((Model) => $"آزمونی با آیدی {Model.ExamId} یافت نشد.");
            RuleFor(e => e.StudentChoice).MustAsync(async (Model, StudentChoice, Token) =>
            {
                if (StudentChoice == null)
                {
                    return true;
                }
                var question = await _multipleChoiceQuestionRepository.GetAsync(Model.QuestionId);
                if (question == null)
                {
                    return false;
                }
                int choicec = question.Choices.Count;
                if (StudentChoice == 0 || StudentChoice > choicec)
                {
                    return false;
                }
                return true;
            }).WithMessage("گزینه انتخابی باید بین گزینه ها باشد.");
        }
    }
}
