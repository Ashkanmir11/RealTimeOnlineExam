using MediatR;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.ClassRoom.Request.Queries
{
    public class GetClassRoomStudentRequest : IRequest<PaginateResponse<GetClassRoomStudentDTO>>
    {
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
