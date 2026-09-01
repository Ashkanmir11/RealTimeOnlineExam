using MediatR;
using OnlineExam.Application.DTOs.ClassRoomMember;

namespace OnlineExam.Application.Features.ClassRoomMember.Request.Commands
{
    public class UpdateClassRoomMemberRequest : IRequest
    {

        public required UpdateClassRoomMemberDTO UpdateClassRoomMemberDTO { get; set; }
    }
}
