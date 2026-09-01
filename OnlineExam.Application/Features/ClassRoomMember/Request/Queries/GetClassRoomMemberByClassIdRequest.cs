using MediatR;
using OnlineExam.Application.DTOs.ClassRoomMember;

namespace OnlineExam.Application.Features.ClassRoomMember.Request.Queries
{
    public class GetClassRoomMemberByClassIdRequest : IRequest<GetClassRoomMemberDTO>
    {
        public int ClassRoomId { get; set; }
    }
}
