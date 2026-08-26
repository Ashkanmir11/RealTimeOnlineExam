using MediatR;
using OnlineExam.Application.DTOs.ClassRoom;

namespace OnlineExam.Application.Features.ClassRoom.Request.Queries
{
    public class GetClassRoomByIdRequest : IRequest<GetClassRoomDTO>
    {
        public int Id { get; set; }
    }
}
