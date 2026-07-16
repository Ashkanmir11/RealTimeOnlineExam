using OnlineExam.Application.Exceptions;
using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoomMember.Validation;
using OnlineExam.Application.Features.ClassRoomMember.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoomMember.Handler.Commands
{
    public class UpdateClassRoomMemberRequestHandler : IRequestHandler<UpdateClassRoomMemberRequest>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IClassRoomMembersRepository _classRoomMembersRepository;
        private readonly IClassRoomRepository _classRoomRepository;
        public UpdateClassRoomMemberRequestHandler(IAccountRepository accountRepository, IClassRoomMembersRepository classRoomMembersRepository, IClassRoomRepository classRoomRepository)
        {
            _accountRepository = accountRepository;
            _classRoomMembersRepository = classRoomMembersRepository;
            _classRoomRepository = classRoomRepository;
        }
        public async Task Handle(UpdateClassRoomMemberRequest request, CancellationToken cancellationToken)
        {
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
