using AutoMapper;
//using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.ClassRoom.Validation;
using OnlineExam.Application.Features.ClassRoom.Request.Command;
using OnlineExam.Application.Helper;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Application.Features.ClassRoom.Handler.Command
{
    public class UpdateClassRoomRequestHandler : IRequestHandler<UpdateClassRoomRequest>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IMapper _mapper;
        public UpdateClassRoomRequestHandler(IClassRoomRepository classRoomRepository, IMapper mapper)
        {
            _classRoomRepository = classRoomRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateClassRoomRequest request, CancellationToken cancellationToken)
        {
            var classRoom = await _classRoomRepository.GetAsync(request.UpdateClassRoomDTO.Id);
            if (classRoom == null)
            {
                throw new BadRequestException($"آیدی {request.UpdateClassRoomDTO.Id} یافت نشد.");
            }
            if (classRoom.TeacherId != request.UserId)
            {
                throw new UnauthorizedAccessException();
            }

            var validator = new UpdateClassRoomValidation(_classRoomRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateClassRoomDTO);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(ListToStringHelper.CreateString(validationResult.Errors.Select(e => e.ErrorMessage).ToList()));
            }          
            await _classRoomRepository.UpdateAsync(request.UpdateClassRoomDTO.Id, request.UpdateClassRoomDTO);
        }
    }
}
