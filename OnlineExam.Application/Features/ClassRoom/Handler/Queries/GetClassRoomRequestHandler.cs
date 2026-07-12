using AutoMapper;
using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.Features.ClassRoom.Request.Queries;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoom.Handler.Queries
{
    public class GetClassRoomRequestHandler : IRequestHandler<GetClassRoomRequest, PaginateResponse<GetClassRoomDTO>>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IMapper _mapper;
        public GetClassRoomRequestHandler(IClassRoomRepository classRoomRepository, IMapper mapper)
        {
            _classRoomRepository = classRoomRepository;
            _mapper = mapper;
        }

        public async Task<PaginateResponse<GetClassRoomDTO>> Handle(GetClassRoomRequest request, CancellationToken cancellationToken)
        {
            return await _classRoomRepository.GetAllAsync<GetClassRoomDTO>(request.PaginateRequest);    
        }
    }
}
