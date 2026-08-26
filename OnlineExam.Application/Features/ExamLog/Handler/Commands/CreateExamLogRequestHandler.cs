using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ExamLog;
using OnlineExam.Application.Features.ExamLog.Request.Commands;

namespace OnlineExam.Application.Features.ExamLog.Handler.Commands
{
    public class CreateExamLogRequestHandler : IRequestHandler<CreateExamLogRequest>
    {
        private readonly IExamLogRepository _examLogRepository;
        private readonly IValidator<CreateExamLogDTO> _validator;
        private readonly IAuthServices _authServices;
        public CreateExamLogRequestHandler(IExamLogRepository examLogRepository, IValidator<CreateExamLogDTO> validator, IAuthServices authServices)
        {
            _examLogRepository = examLogRepository;
            _validator = validator;
            _authServices = authServices;
        }

        public async Task Handle(CreateExamLogRequest request, CancellationToken cancellationToken)
        {
            request.CreateExamLogDTO.StudentId = await _authServices.GetCurrentUserIdAsync();
            var validationResult = await _validator.ValidateAsync(request.CreateExamLogDTO);
            if (validationResult.IsValid == false)
            {
                var erroes = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(erroes);
            }
            await _examLogRepository.AddAsync<CreateExamLogDTO>(request.CreateExamLogDTO);
        }
    }
}
