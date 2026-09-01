using MediatR;
using OnlineExam.Application.DTOs.ClassRoom;

namespace OnlineExam.Application.Features.ClassRoom.Request.Command
{
    public class CreateClassRoomRequest : IRequest<GetClassRoomDTO>
    {
        public CreateClassRoomDTO? CreateClassRoomDTO { get; set; }
    }
}
