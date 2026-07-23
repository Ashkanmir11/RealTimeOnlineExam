using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.ClassRoom.Request.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Contracts.Identity;

namespace OnlineExam.Application.Features.ClassRoom.Handler.Command
{
    public class DeleteClassRoomRequstHandler : IRequestHandler<DeleteClassRoomRequest, Unit>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IAuthServices _authServices;
        public DeleteClassRoomRequstHandler(IClassRoomRepository classRoomRepository,IAuthServices authServices)
        {
            _classRoomRepository = classRoomRepository;
            _authServices = authServices;
        }

        public async Task<Unit> Handle(DeleteClassRoomRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var classRoom = await _classRoomRepository.GetAsync(request.Id);

            bool isUserAdmin=await _authServices.IsUserAdminAsync(currentUser);
            if(classRoom.TeacherId!=currentUser &&  !isUserAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی به این عملیات را ندارید.");
            }



            if (classRoom == null)
            {
                throw new NotFoundException($"آیدی {request.Id} یافت نشد.");
            }          
            await _classRoomRepository.DeleteAsync(classRoom);
            return Unit.Value;
        }

        
    }
}
