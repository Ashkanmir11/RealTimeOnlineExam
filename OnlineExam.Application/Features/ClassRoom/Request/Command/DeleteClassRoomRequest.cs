using MediatR;

namespace OnlineExam.Application.Features.ClassRoom.Request.Command
{
    public class DeleteClassRoomRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
