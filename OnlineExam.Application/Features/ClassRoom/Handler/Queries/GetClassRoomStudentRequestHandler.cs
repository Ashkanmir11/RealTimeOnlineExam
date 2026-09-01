using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.Features.ClassRoom.Request.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.ClassRoom.Handler.Queries
{
    public class GetClassRoomStudentRequestHandler : IRequestHandler<GetClassRoomStudentRequest, PaginateResponse<GetClassRoomStudentDTO>>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IAuthServices _authServices;
        public GetClassRoomStudentRequestHandler(IClassRoomRepository classRoomRepository, IAuthServices authServices)
        {
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
