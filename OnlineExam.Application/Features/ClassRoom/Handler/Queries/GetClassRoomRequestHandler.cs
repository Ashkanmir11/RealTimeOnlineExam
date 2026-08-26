using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.Features.ClassRoom.Request.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.ClassRoom.Handler.Queries
{
    public class GetClassRoomRequestHandler : IRequestHandler<GetClassRoomRequest, PaginateResponse<GetClassRoomDTO>>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        public GetClassRoomRequestHandler(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
        }

        public async Task<PaginateResponse<GetClassRoomDTO>> Handle(GetClassRoomRequest request, CancellationToken cancellationToken)
        {
            return await _classRoomRepository.GetAllAsync<GetClassRoomDTO>(request.PaginateRequest);
        }
    }
}
