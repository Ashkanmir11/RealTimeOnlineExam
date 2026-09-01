using MediatR;
using OnlineExam.Application.DTOs.ClassRoomMember;

namespace OnlineExam.Application.Features.ClassRoomMember.Request.Commands
{
    public class CreateClassRoomMemberRequest : IRequest
    {
        public required CreateClassRoomMemberDTO CreateClassRoomMemberDTO { get; set; }
    }
}
