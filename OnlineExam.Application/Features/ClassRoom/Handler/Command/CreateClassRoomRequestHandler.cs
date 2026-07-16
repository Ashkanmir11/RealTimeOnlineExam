using AutoMapper;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.ClassRoom.Validation;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.ClassRoom.Request.Command;
using OnlineExam.Application.Helper;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoom.Handler.Command
{
    public class CreateClassRoomRequestHandler : IRequestHandler<CreateClassRoomRequest, GetClassRoomDTO>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IAuthServices _authServices;
        private readonly IValidator<CreateClassRoomDTO> _validator;

        public CreateClassRoomRequestHandler(IClassRoomRepository classRoomRepository, IMapper mapper, 
            IAccountRepository accountRepository, IAuthServices authServices,IValidator<CreateClassRoomDTO> validator)
        {
            _classRoomRepository = classRoomRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;
            _authServices = authServices;
            _validator = validator;
        }
        public async Task<GetClassRoomDTO> Handle(CreateClassRoomRequest request, CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(request.CreateClassRoomDTO);

            if (validationResult.IsValid == false)
            {
                var errors =validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);
            }
            request.CreateClassRoomDTO.TeacherId = await _authServices.GetCurrentUserId();

            var result = await _classRoomRepository.AddAsync<CreateClassRoomDTO>(request.CreateClassRoomDTO);
            return _mapper.Map<GetClassRoomDTO>(result);
        }
    }
}
