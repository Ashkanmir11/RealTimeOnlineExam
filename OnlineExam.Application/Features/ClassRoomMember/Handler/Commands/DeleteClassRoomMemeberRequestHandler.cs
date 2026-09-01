using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.ClassRoomMember.Request.Commands;

namespace OnlineExam.Application.Features.ClassRoomMember.Handler.Commands
{
    public class DeleteClassRoomMemeberRequestHandler : IRequestHandler<DeleteClassRoomMemeberRequest>
    {
        private readonly IClassRoomMembersRepository _classRoomMemberRepository;
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IAuthServices _authServices;
        public DeleteClassRoomMemeberRequestHandler(IClassRoomMembersRepository classRoomMemberRepository, IClassRoomRepository classRoomRepository, IAuthServices authServices)
        {
            _classRoomMemberRepository = classRoomMemberRepository;
            _classRoomRepository = classRoomRepository;
            _authServices = authServices;
        }

        public async Task Handle(DeleteClassRoomMemeberRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            bool isTeacher = await _classRoomRepository.IsUserTeacherAsync(request.ClassId, currentUser);
            if (isTeacher == false)
            {
                throw new AccessForbiddenException("شما دسترسی به این کلاس را ندارید");
            }


            var classRoomMember = await _classRoomMemberRepository.GetAsync(request.ClassId, request.StudentId);
            if (classRoomMember == null)
            {
                throw new NotFoundException("عضو کلاسی یافت نشد.");
            }

            await _classRoomMemberRepository.DeleleAsync(classRoomMember);
        }
    }
}
