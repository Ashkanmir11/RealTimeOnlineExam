using MediatR;
using OnlineExam.Application.DTOs.ClassRoomMember;
using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Application.Features.ClassRoomMember.Request.Queries
{
    public class GetClassRoomMemberRequest : IRequest<List<GetClassRoomMemberDTO>>
    {
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
