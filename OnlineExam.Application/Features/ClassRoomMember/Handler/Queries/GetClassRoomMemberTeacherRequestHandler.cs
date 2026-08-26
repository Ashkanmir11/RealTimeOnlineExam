using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoomMember;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.ClassRoomMember.Request.Queries;
namespace OnlineExam.Application.Features.ClassRoomMember.Handler.Queries
{
    public class GetClassRoomMemberTeacherRequestHandler : IRequestHandler<GetClassRoomMemberTeacherRequest, GetClassRoomMemberTeacherDTO>
    {
        private readonly IClassRoomMembersRepository _classRoomMembersRepository;
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthServices _authServices;
        public GetClassRoomMemberTeacherRequestHandler(IClassRoomMembersRepository classRoomMembersRepository
            , IClassRoomRepository classRoomRepository, IAccountRepository accountRepository, IAuthServices authServices)
        {
            _classRoomMembersRepository = classRoomMembersRepository;
            _classRoomRepository = classRoomRepository;
            _accountRepository = accountRepository;
            _authServices = authServices;
        }
        public async Task<GetClassRoomMemberTeacherDTO> Handle(GetClassRoomMemberTeacherRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            bool isTeacher = await _classRoomRepository.IsUserTeacherAsync(request.ClassId, currentUser);
            if (!isTeacher)
            {
                throw new AccessForbiddenException("شما دسترسی به این کلاس ندارید.");
            }
            var result = new GetClassRoomMemberTeacherDTO();
            result.Students = new List<DTOs.Identity.GetUserDTO>();
            var membersId = await _classRoomMembersRepository.GetStudentByClassIdAsync(request.ClassId);
            var classRoom = await _classRoomRepository.GetAsync(request.ClassId);
            result.ClassName = classRoom.ClassName;
            foreach (var memberId in membersId)
            {
                var user = await _accountRepository.GetUserByIdAsync(memberId);
                result.Students.Add(user);
            }
            return result;
        }
    }
}
