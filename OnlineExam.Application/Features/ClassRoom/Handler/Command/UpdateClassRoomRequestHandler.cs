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
using OnlineExam.Application.Contracts.Identity;
namespace OnlineExam.Application.Features.ClassRoom.Handler.Command
{
    public class UpdateClassRoomRequestHandler : IRequestHandler<UpdateClassRoomRequest>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IAuthServices _authServices;
        public UpdateClassRoomRequestHandler(IClassRoomRepository classRoomRepository, IAuthServices authServices)
        {
            _classRoomRepository = classRoomRepository;
            _authServices = authServices;
        }

        public async Task Handle(UpdateClassRoomRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var classRoom = await _classRoomRepository.GetAsync(request.UpdateClassRoomDTO.Id);
            bool isUserAdmin = await _authServices.IsUserAdminAsync(currentUser);
            if (classRoom.TeacherId != currentUser && !isUserAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی به این عملیات را ندارید.");
            }

            if (classRoom == null)
            {
                throw new NotFoundException($"آیدی {request.UpdateClassRoomDTO.Id} یافت نشد.");
            }
            var validator = new UpdateClassRoomValidation(_classRoomRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateClassRoomDTO);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }          
            await _classRoomRepository.UpdateAsync(request.UpdateClassRoomDTO.Id, request.UpdateClassRoomDTO);
        }
    }
}
