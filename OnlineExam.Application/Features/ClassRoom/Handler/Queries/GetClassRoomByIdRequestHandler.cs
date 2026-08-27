using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.Features.ClassRoom.Request.Queries;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Application.Features.ClassRoom.Handler.Queries
{
    public class GetClassRoomByIdRequestHandler : IRequestHandler<GetClassRoomByIdRequest, GetClassRoomDTO>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IAuthServices _authServices;
        public GetClassRoomByIdRequestHandler(IClassRoomRepository classRoomRepository, IAuthServices authServices)
        {
            _classRoomRepository = classRoomRepository;
            _authServices = authServices;
        }

        public async Task<GetClassRoomDTO> Handle(GetClassRoomByIdRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var isUserTeacher = await _classRoomRepository.IsUserTeacherAsync(request.Id, currentUser);
            if (!isUserTeacher)
            {
                throw new AccessForbiddenException("شما دسترسی به این کلاس را ندارید.");
            }
            return await _classRoomRepository.GetAsync<GetClassRoomDTO>(request.Id);
        }
    }
}
