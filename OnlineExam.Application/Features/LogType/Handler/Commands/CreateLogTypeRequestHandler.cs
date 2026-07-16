using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.LogType;
using OnlineExam.Application.DTOs.LogType.Validation;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.LogType.Reqeust.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.LogType.Handler.Commands
{
    public class CreateLogTypeRequestHandler : IRequestHandler<CreateLogTypeRequest>
    {
        private readonly ILogTypeRepository _logTypeRepository;
        public CreateLogTypeRequestHandler(ILogTypeRepository logTypeRepository)
        {
            _logTypeRepository = logTypeRepository;
        }
        public async Task Handle(CreateLogTypeRequest request, CancellationToken cancellationToken)
        {
            var validation = new CreateLogTypeValidation();
            var validationResult = await validation.ValidateAsync(request.CreateLogTypeDTO);
            if(validationResult.IsValid==false)
            {
                throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

           await _logTypeRepository.AddAsync<CreateLogTypeDTO>(request.CreateLogTypeDTO);
           
        }
    }
}
