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
        private readonly IMapper _mapper;
        public GetClassRoomByIdRequestHandler(IClassRoomRepository classRoomRepository, IMapper mapper)
        {
            _classRoomRepository = classRoomRepository;
            _mapper = mapper;
        }

        public async Task<GetClassRoomDTO> Handle(GetClassRoomByIdRequest request, CancellationToken cancellationToken)
        {
            var response =await _classRoomRepository.GetAsync(request.Id);
            var result=_mapper.Map<GetClassRoomDTO>(response);
            return result;
        }
    }
}
