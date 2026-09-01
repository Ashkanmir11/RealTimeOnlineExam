using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.LogType;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.LogType.Reqeust.Queries
{
    public class GetLogTypeRequest : IRequest<PaginateResponse<GetLogTypeDTO>>
    {
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
