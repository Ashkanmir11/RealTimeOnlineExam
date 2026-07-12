using FluentValidation;
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
    public class CreateClassRoomMemberRequestHandler : IRequestHandler<CreateClassRoomMemberRequest>
    {
        private readonly IClassRoomMembersRepository _classRoomMembersRepository;
        private readonly IClassRoomRepository _classRoomRepository;
        public CreateClassRoomMemberRequestHandler(IClassRoomMembersRepository classRoomMembersRepository, IClassRoomRepository classRoomRepository)
        {
            _classRoomMembersRepository = classRoomMembersRepository;
            _classRoomRepository = classRoomRepository;
        }

        public async Task Handle(CreateClassRoomMemberRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateClassRoomMemberValidation(_classRoomMembersRepository, _classRoomRepository);
            var validatioResult = await validator.ValidateAsync(request.CreateClassRoomMemberDTO);
            if(validatioResult.IsValid==false)
            {
                throw new ValidationException(ListToStringHelper.CreateString(validatioResult.Errors.Select(e => e.ErrorMessage).ToList()));
            }

           await _classRoomMembersRepository.AddMembersAsync(request.CreateClassRoomMemberDTO);
        }
    }
}
