using FluentValidation;

namespace OnlineExam.Application.DTOs.MultipleChoiceQuestion.Validation
{
    public class CreateMultipleChoiceQuestionValidation : AbstractValidator<CreateMultipleChoiceQuestionDTO>
    {

        public CreateMultipleChoiceQuestionValidation()
        {

            RuleFor(e => e.Choices).Must(Model =>
            {
                if (Model.Count <= 0)
                {
                    return false;
                }
                return true;
            }).WithMessage((Model) => $"انتخاب ها نباید خالی باشند.");
            RuleFor(e => e.CorrectChoice).Must((Model, CorrectChoice) =>
            {
                if (Model.Choices.Count < CorrectChoice || CorrectChoice <= 0)
                {
                    return false;
                }
                return true;
            }).WithMessage($"پاسخ صحیح باید بین گزینه ها باشد.");
        }
    }
}
