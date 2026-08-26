using FluentValidation;

namespace OnlineExam.Application.DTOs.DescriptiveQuestion.Validation
{
    public class CreateDescriptiveQuestionValidation : AbstractValidator<CreateDescriptiveQuestionDTO>
    {
        public CreateDescriptiveQuestionValidation()
        {
            RuleFor(e => e.CorrectAnswer).MaximumLength(1000).WithMessage("پاسخ درست نباید بیشتر از 1000 کاراکتر باشد.");

        }
    }
}
