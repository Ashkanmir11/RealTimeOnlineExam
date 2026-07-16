using FluentValidation;
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
        private readonly IValidator<CreateLogTypeDTO> _validator;
        public CreateLogTypeRequestHandler(ILogTypeRepository logTypeRepository, IValidator<CreateLogTypeDTO> validator)
        {
            _logTypeRepository = logTypeRepository;
            _validator = validator;
        }
        public async Task Handle(CreateLogTypeRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.CreateLogTypeDTO);
            if(validationResult.IsValid==false)
            {
                throw new Application.Exceptions.ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

           await _logTypeRepository.AddAsync<CreateLogTypeDTO>(request.CreateLogTypeDTO);
           
        }
    }
}
