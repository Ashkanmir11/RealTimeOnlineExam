using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.Features.ClassRoom.Request.Queries;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoom.Handler.Queries
{
    public class GetClassRoomTeacherRequestHandler : IRequestHandler<GetClassRoomTeacherRequest, PaginateResponse<GetClassRoomTeacherDTO>>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IAuthServices _authServices;
        public GetClassRoomTeacherRequestHandler(IClassRoomRepository classRoomRepository, IAuthServices authServices)
        {
            _classRoomRepository = classRoomRepository;
            _authServices = authServices;
        }

        public async Task<PaginateResponse<GetClassRoomTeacherDTO>> Handle(GetClassRoomTeacherRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var result = await _classRoomRepository.GetTeacherClassAsync(currentUser, request.PaginateRequestDTO);
            return result;
        }
    }
}
