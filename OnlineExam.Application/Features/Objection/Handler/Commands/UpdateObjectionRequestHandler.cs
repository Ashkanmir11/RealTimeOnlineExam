using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Objection;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.Objection.Request.Commands;
namespace OnlineExam.Application.Features.Objection.Handler.Commands
{
    public class UpdateObjectionRequestHandler : IRequestHandler<UpdateObjectionRequest>
    {
        private readonly IObjectionRepository _objectionRepository;
        private readonly IValidator<UpdateObjectionDTO> _validator;
        public UpdateObjectionRequestHandler(IObjectionRepository objectionRepository, IValidator<UpdateObjectionDTO> validator)
        {
            _objectionRepository = objectionRepository;
            _validator = validator;
        }
        public async Task Handle(UpdateObjectionRequest request, CancellationToken cancellationToken)
        {
            var exist = await _objectionRepository.ExistAsync(request.Id);
            if (exist == false)
            {
                throw new NotFoundException("اعتراض یافت نشد.");
            }
            var validatorResult = await _validator.ValidateAsync(request.UpdateObjectionDTO);
            if (validatorResult.IsValid == false)
            {
                var errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);
            }
            //TODO 
            //Add Check User Access

            await _objectionRepository.UpdateAsync(request.Id, request.UpdateObjectionDTO);
        }
    }
}
