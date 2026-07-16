using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.LogType.Validation;
using OnlineExam.Application.DTOs.LogType;
using OnlineExam.Application.Features.LogType.Reqeust.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;

namespace OnlineExam.Application.Features.LogType.Handler.Commands
{
    public class UpdateLogTypeRequestHandler : IRequestHandler<UpdateLogTypeRequest>
    {
        private readonly ILogTypeRepository _logTypeRepository;
        public UpdateLogTypeRequestHandler(ILogTypeRepository logTypeRepository)
        {
            _logTypeRepository = logTypeRepository;
        }
        public async Task Handle(UpdateLogTypeRequest request, CancellationToken cancellationToken)
        {
            var validation = new UpdateLogTypeValidation(_logTypeRepository);
            var validationResult = await validation.ValidateAsync(request.UpdateLogTypeDTO);
            if (validationResult.IsValid == false)
            {
                throw (new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList()));
            }

            await _logTypeRepository.UpdateAsync<UpdateLogTypeDTO>(request.UpdateLogTypeDTO.Id, request.UpdateLogTypeDTO);
        }
    }
}
