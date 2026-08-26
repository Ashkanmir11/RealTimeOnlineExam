using MediatR;
using OnlineExam.Application.DTOs.ClassRoomMember;

namespace OnlineExam.Application.Features.ClassRoomMember.Request.Queries
{
    public class GetClassRoomMemberTeacherRequest : IRequest<GetClassRoomMemberTeacherDTO>
    {
        public int ClassId { get; set; }
    }
}
