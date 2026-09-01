using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.LogType;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.LogType.Reqeust.Commands;

namespace OnlineExam.Application.Features.LogType.Handler.Commands
{
    public class UpdateLogTypeRequestHandler : IRequestHandler<UpdateLogTypeRequest>
    {
        private readonly ILogTypeRepository _logTypeRepository;
        private readonly IValidator<UpdateLogTypeDTO> _validator;
        public UpdateLogTypeRequestHandler(ILogTypeRepository logTypeRepository, IValidator<UpdateLogTypeDTO> validator)
        {
            _logTypeRepository = logTypeRepository;
            _validator = validator;
        }
        public async Task Handle(UpdateLogTypeRequest request, CancellationToken cancellationToken)
        {
            var logTypeExist = await _logTypeRepository.ExistAsync(request.Id);
            if (logTypeExist == false)
            {
                throw new NotFoundException("نوع لاگ یافت نشد.");
            }
            var validationResult = await _validator.ValidateAsync(request.UpdateLogTypeDTO);
            if (validationResult.IsValid == false)
            {
                throw new Application.Exceptions.ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            await _logTypeRepository.UpdateAsync<UpdateLogTypeDTO>(request.Id, request.UpdateLogTypeDTO);
        }
    }
}
