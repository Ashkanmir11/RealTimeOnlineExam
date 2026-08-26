using MediatR;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.ClassRoom.Request.Queries
{
    public class GetClassRoomRequest : IRequest<PaginateResponse<GetClassRoomDTO>>
    {
        public PaginateRequestDTO PaginateRequest { get; set; }
    }
}
