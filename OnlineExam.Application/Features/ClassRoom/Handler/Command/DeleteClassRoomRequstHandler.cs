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

namespace OnlineExam.Application.Features.ClassRoom.Handler.Command
{
    public class DeleteClassRoomRequstHandler : IRequestHandler<DeleteClassRoomRequest, Unit>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        //private readonly UserManager<onlineExamuse>
        public DeleteClassRoomRequstHandler(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
        }

        public async Task<Unit> Handle(DeleteClassRoomRequest request, CancellationToken cancellationToken)
        {
            var classRoom = await _classRoomRepository.GetAsync(request.Id);
            if (classRoom == null)
            {
                throw new BadRequestException($"آیدی {request.Id} یافت نشد.");
            }
            await _classRoomRepository.DeleteAsync(classRoom);
            return Unit.Value;
        }

        
    }
}
