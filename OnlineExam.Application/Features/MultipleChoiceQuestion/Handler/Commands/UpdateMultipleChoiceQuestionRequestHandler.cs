using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion.Validation;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Commands;


namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Handler.Commands
{
    public class UpdateMultipleChoiceQuestionRequestHandler : IRequestHandler<UpdateMultipleChoiceQuestionRequest>
    {
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;
        public UpdateMultipleChoiceQuestionRequestHandler(IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository)
        {
            _multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
        }

        public async Task Handle(UpdateMultipleChoiceQuestionRequest request, CancellationToken cancellationToken)
        {
            var validtor = new UpdateMultipleChoiceQuestionValidation(_multipleChoiceQuestionRepository);
            var validationResult = await validtor.ValidateAsync(request.UpdateMultipleChoiceQuestionDTO);
            if (validationResult.IsValid == false)
            {
                var validtionErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationException(validtionErrors);
            }

            await _multipleChoiceQuestionRepository.UpdateAsync(request.UpdateMultipleChoiceQuestionDTO.Id, request.UpdateMultipleChoiceQuestionDTO);
        }
    }
}
