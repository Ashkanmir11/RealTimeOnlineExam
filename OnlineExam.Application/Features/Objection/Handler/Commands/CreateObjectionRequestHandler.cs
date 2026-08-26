using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Objection;
using OnlineExam.Application.Features.Objection.Request.Commands;

namespace OnlineExam.Application.Features.Objection.Handler.Commands
{
    public class CreateObjectionRequestHandler : IRequestHandler<CreateObjectionReqeust>
    {
        private readonly IObjectionRepository _objectionRepository;
        private readonly IAuthServices _authServices;
        private readonly IValidator<CreateObjectionDTO> _validator;
        public CreateObjectionRequestHandler(IObjectionRepository objectionRepository, IAuthServices authServices, IValidator<CreateObjectionDTO> validator)
        {
            _objectionRepository = objectionRepository;
            _authServices = authServices;
            _validator = validator;
        }

        public async Task Handle(CreateObjectionReqeust request, CancellationToken cancellationToken)
        {
            var validatorResult = await _validator.ValidateAsync(request.CreateObjectionDTO);
            if (validatorResult.IsValid == false)
            {
                throw new Application.Exceptions.ValidationException(validatorResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            request.CreateObjectionDTO.StudentId = await _authServices.GetCurrentUserIdAsync();
            await _objectionRepository.AddAsync<CreateObjectionDTO>(request.CreateObjectionDTO);

        }
    }
}
