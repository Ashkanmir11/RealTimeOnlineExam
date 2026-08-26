using FluentValidation;
using OnlineExam.Application.Contracts.Persistence;

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
            }).WithMessage((Model) => $"آزمون با آیدی  {Model.ExamId} یافت نشد.");
        }
    }
}
