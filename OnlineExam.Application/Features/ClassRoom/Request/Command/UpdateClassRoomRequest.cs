using MediatR;
using OnlineExam.Application.DTOs.ClassRoom;

namespace OnlineExam.Application.Features.ClassRoom.Request.Command
{
    public class UpdateClassRoomRequest : IRequest
    {
        public int Id { get; set; }
        public UpdateClassRoomDTO? UpdateClassRoomDTO { get; set; }
    }
}
