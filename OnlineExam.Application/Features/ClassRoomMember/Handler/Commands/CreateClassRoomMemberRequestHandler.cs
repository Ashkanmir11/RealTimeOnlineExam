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
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthServices _authServices;
        private readonly IClassRoomRepository _classRoomRepository;
        public CreateClassRoomMemberRequestHandler(IClassRoomMembersRepository classRoomMembersRepository
            , IValidator<CreateClassRoomMemberDTO> validator,IAccountRepository accountRepository, IAuthServices authServices, IClassRoomRepository classRoomRepository)
        {
            _classRoomMembersRepository = classRoomMembersRepository;
            _validator = validator;
            _accountRepository = accountRepository;
            _authServices = authServices;
            _classRoomRepository = classRoomRepository;
        }

        public async Task Handle(CreateClassRoomMemberRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var classRoom = await _classRoomRepository.GetAsync(request.CreateClassRoomMemberDTO.ClassRomeId);

            bool isUserAdmin = await _authServices.IsUserAdminAsync(currentUser);
            if (classRoom.TeacherId != currentUser && !isUserAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی به این عملیات را ندارید.");
            }


            request.CreateClassRoomMemberDTO.StudentIDs = await _accountRepository.GetUsersIdByPhonesAsync(request.CreateClassRoomMemberDTO.Phones);
            var validatioResult = await _validator.ValidateAsync(request.CreateClassRoomMemberDTO);
            if(validatioResult.IsValid==false)
            {
                throw new Application.Exceptions.ValidationException(validatioResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

           await _classRoomMembersRepository.AddMembersAsync(request.CreateClassRoomMemberDTO);
        }
    }
}
