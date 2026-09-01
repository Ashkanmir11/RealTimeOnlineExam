using MediatR;

namespace OnlineExam.Application.Features.ClassRoomMember.Request.Commands
{
    public class DeleteClassRoomMemeberRequest : IRequest
    {
        public int ClassId { get; set; }
        public string? StudentId { get; set; }
    }
}
