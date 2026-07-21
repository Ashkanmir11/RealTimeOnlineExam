using AutoMapper;
using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.Features.ClassRoom.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoom.Handler.Queries
{
    public class GetClassRoomByIdRequestHandler : IRequestHandler<GetClassRoomByIdRequest, GetClassRoomDTO>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        public GetClassRoomByIdRequestHandler(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
        }

        public async Task<GetClassRoomDTO> Handle(GetClassRoomByIdRequest request, CancellationToken cancellationToken)
        {
            return await _classRoomRepository.GetAsync<GetClassRoomDTO>(request.Id);
        }
    }
}
