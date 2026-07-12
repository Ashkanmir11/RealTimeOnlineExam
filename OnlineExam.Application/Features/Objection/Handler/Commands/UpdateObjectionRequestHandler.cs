using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Objection.Validation;
using OnlineExam.Application.Features.Objection.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Objection.Handler.Commands
{
    public class UpdateObjectionRequestHandler : IRequestHandler<UpdateObjectionRequest>
    {
        private readonly IObjectionRepository _objectionRepository;
        public UpdateObjectionRequestHandler(IObjectionRepository objectionRepository)
        {
            _objectionRepository = objectionRepository;
        }
        public async Task Handle(UpdateObjectionRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateObjectionValidation();
            var validatorResult = await validator.ValidateAsync(request.UpdateObjectionDTO);

            //TODO 
            //Add Check User Access

            await _objectionRepository.UpdateAsync(request.UpdateObjectionDTO.Id, request.UpdateObjectionDTO);
        }
    }
}
