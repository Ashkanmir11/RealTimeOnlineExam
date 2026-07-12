using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.ClassRoomMember;
using OnlineExam.Application.Features.ClassRoomMember.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoomMember.Handler.Queries
{
    public class GetClassRoomMemberByClassIdRequestHandler : IRequestHandler<GetClassRoomMemberByClassIdRequest, GetClassRoomMemberDTO>
    {
        private readonly IClassRoomMembersRepository _classRoomMembersRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IClassRoomRepository _classRoomRepository;
        public GetClassRoomMemberByClassIdRequestHandler(IClassRoomMembersRepository classRoomMembersRepository, IClassRoomRepository classRoomRepository, IAccountRepository accountRepository)
        {
            _classRoomMembersRepository = classRoomMembersRepository;
            _classRoomRepository = classRoomRepository;
            _accountRepository = accountRepository;
        }
        public async Task<GetClassRoomMemberDTO> Handle(GetClassRoomMemberByClassIdRequest request, CancellationToken cancellationToken)
        {
            var studentsId = await _classRoomMembersRepository.GetStudentByClassIdAsync(request.ClassRoomId);
            var result = new GetClassRoomMemberDTO()
            {
                GetClassRoomDTO = await _classRoomRepository.GetAsync<GetClassRoomDTO>(request.ClassRoomId),
                Students =await _accountRepository.GetUsersByIds(studentsId)
            };
            return result;
        }
    }
}
