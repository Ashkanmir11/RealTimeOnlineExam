using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.ClassRoomMember;
using OnlineExam.Application.Features.ClassRoomMember.Request.Queries;

namespace OnlineExam.Application.Features.ClassRoomMember.Handler.Queries
{
    public class GetClassRoomMemberRequestHandler : IRequestHandler<GetClassRoomMemberRequest, List<GetClassRoomMemberDTO>>
    {
        private readonly IClassRoomMembersRepository _classRoomMembersRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IClassRoomRepository _classRoomRepository;
        public GetClassRoomMemberRequestHandler(IClassRoomMembersRepository classRoomMembersRepository, IClassRoomRepository classRoomRepository, IAccountRepository accountRepository)
        {
            _classRoomMembersRepository = classRoomMembersRepository;
            _classRoomRepository = classRoomRepository;
            _accountRepository = accountRepository;
        }
        public async Task<List<GetClassRoomMemberDTO>> Handle(GetClassRoomMemberRequest request, CancellationToken cancellationToken)
        {
            var result = new List<GetClassRoomMemberDTO>();
            var classRooms = await _classRoomRepository.GetAllAsync<GetClassRoomDTO>(request.PaginateRequestDTO);
            foreach (var clasRoom in classRooms.Data)
            {
                var classRoomStudents = await _classRoomMembersRepository.GetStudentByClassIdAsync(clasRoom.Id);
                var students = await _accountRepository.GetUsersByIdsAsync(classRoomStudents);
                result.Add(new GetClassRoomMemberDTO()
                {
                    Students = students,
                    GetClassRoomDTO = clasRoom,
                });
            }
            return result;

        }
    }
}
