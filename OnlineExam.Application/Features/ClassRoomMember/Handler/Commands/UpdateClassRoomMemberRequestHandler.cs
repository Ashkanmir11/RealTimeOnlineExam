using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoomMember.Validation;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.ClassRoomMember.Request.Commands;

namespace OnlineExam.Application.Features.ClassRoomMember.Handler.Commands
{
    public class UpdateClassRoomMemberRequestHandler : IRequestHandler<UpdateClassRoomMemberRequest>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IClassRoomMembersRepository _classRoomMembersRepository;
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IAuthServices _authServices;
        public UpdateClassRoomMemberRequestHandler(IAccountRepository accountRepository, IClassRoomMembersRepository classRoomMembersRepository
            , IClassRoomRepository classRoomRepository, IAuthServices authServices)
        {
            _accountRepository = accountRepository;
            _classRoomMembersRepository = classRoomMembersRepository;
            _classRoomRepository = classRoomRepository;
            _authServices = authServices;
        }
        public async Task Handle(UpdateClassRoomMemberRequest request, CancellationToken cancellationToken)
        {
            request.UpdateClassRoomMemberDTO.StudentIDs = await _accountRepository.GetUsersIdByPhonesAsync(request.UpdateClassRoomMemberDTO.Phones);

            var currentUser = await _authServices.GetCurrentUserIdAsync();
            bool isTeacher = await _classRoomRepository.IsUserTeacherAsync(request.UpdateClassRoomMemberDTO.ClasRoomId, currentUser);
            if (isTeacher == false)
            {
                throw new AccessForbiddenException("شما دسترسی به این کلاس را ندارید");
            }

            var validator = new UpdateClassRoomMemberValidation(_accountRepository, _classRoomRepository);
            var validatResult = await validator.ValidateAsync(request.UpdateClassRoomMemberDTO);
            if (validatResult.IsValid == false)
            {
                throw new ValidationException(validatResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            await _classRoomMembersRepository.UpdateClassRoomAsync(request.UpdateClassRoomMemberDTO);
        }
    }
}
