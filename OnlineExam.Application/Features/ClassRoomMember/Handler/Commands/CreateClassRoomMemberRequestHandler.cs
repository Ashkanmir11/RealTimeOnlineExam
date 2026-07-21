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
using OnlineExam.Application.Exceptions;
using FluentValidation;
using OnlineExam.Application.DTOs.ClassRoomMember;
namespace OnlineExam.Application.Features.ClassRoomMember.Handler.Commands
{
    public class CreateClassRoomMemberRequestHandler : IRequestHandler<CreateClassRoomMemberRequest>
    {
        private readonly IClassRoomMembersRepository _classRoomMembersRepository;
        private readonly IValidator<CreateClassRoomMemberDTO> _validator;
        public CreateClassRoomMemberRequestHandler(IClassRoomMembersRepository classRoomMembersRepository, IValidator<CreateClassRoomMemberDTO> validator)
        {
            _classRoomMembersRepository = classRoomMembersRepository;
            _validator = validator;
        }

        public async Task Handle(CreateClassRoomMemberRequest request, CancellationToken cancellationToken)
        {
            var validatioResult = await _validator.ValidateAsync(request.CreateClassRoomMemberDTO);
            if(validatioResult.IsValid==false)
            {
                throw new Application.Exceptions.ValidationException(validatioResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

           await _classRoomMembersRepository.AddMembersAsync(request.CreateClassRoomMemberDTO);
        }
    }
}
