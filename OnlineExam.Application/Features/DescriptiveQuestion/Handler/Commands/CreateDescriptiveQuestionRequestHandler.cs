using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.Features.DescriptiveQuestion.Request.Commands;
namespace OnlineExam.Application.Features.DescriptiveQuestion.Handler.Commands
{
    public class CreateDescriptiveQuestionRequestHandler : IRequestHandler<CreateDescriptiveQuestionRequest, int>
    {
        private readonly IDescriptiveQuestionRepository _descriptiveQuestionRepository;
        private readonly IValidator<CreateDescriptiveQuestionDTO> _validator;
        public CreateDescriptiveQuestionRequestHandler(IDescriptiveQuestionRepository descriptiveQuestionRepository, IValidator<CreateDescriptiveQuestionDTO> validator)
        {
            _descriptiveQuestionRepository = descriptiveQuestionRepository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateDescriptiveQuestionRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.CreateDescriptiveQuestionDTO);
            if (validationResult.IsValid == false)
            {
                throw new Application.Exceptions.ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            var result = await _descriptiveQuestionRepository.AddAsync<CreateDescriptiveQuestionDTO>(request.CreateDescriptiveQuestionDTO);
            return result.Id;
        }
    }
}
