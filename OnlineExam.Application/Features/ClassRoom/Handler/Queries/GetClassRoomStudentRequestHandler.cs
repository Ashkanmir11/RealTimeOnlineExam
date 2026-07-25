using MediatR;
using OnlineExam.Application.Contracts.Identity;
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
    public class GetClassRoomStudentRequestHandler : IRequestHandler<GetClassRoomStudentRequest, PaginateResponse<GetClassRoomStudentDTO>>
    {
        private readonly IClassRoomMembersRepository _classRoomMemberRepository;
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IAuthServices _authServices;
        public GetClassRoomStudentRequestHandler(IClassRoomMembersRepository classRoomMemberRepository, IClassRoomRepository classRoomRepository, IAuthServices authServices)
        {
            _classRoomMemberRepository = classRoomMemberRepository;
            _classRoomRepository = classRoomRepository;
            _authServices = authServices;
        }

        public async Task<PaginateResponse<GetClassRoomStudentDTO>> Handle(GetClassRoomStudentRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var result = await _classRoomRepository.GetStudentClassesAsync(currentUser, request.PaginateRequestDTO);
            return result;
        }
    }
}
