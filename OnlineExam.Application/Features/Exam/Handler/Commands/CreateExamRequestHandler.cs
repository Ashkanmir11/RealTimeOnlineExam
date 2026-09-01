using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Features.Exam.Request.Commands;


namespace OnlineExam.Application.Features.Exam.Handler.Commands
{
    public class CreateExamRequestHandler : IRequestHandler<CreateExamRequest>
    {
        private readonly IExamRepository _examRepository;
        private readonly IValidator<CreateExamDTO> _validator;
        public CreateExamRequestHandler(IExamRepository examRepository, IValidator<CreateExamDTO> validator)
        {
            _examRepository = examRepository;
            _validator = validator;
        }

        public async Task Handle(CreateExamRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.CreateExamDTO);
            if (validationResult.IsValid == false)
            {
                throw new Application.Exceptions.ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            await _examRepository.AddAsync<CreateExamDTO>(request.CreateExamDTO);
        }
    }
}
