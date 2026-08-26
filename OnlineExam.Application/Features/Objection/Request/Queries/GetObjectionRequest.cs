using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Objection;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.Objection.Request.Queries
{
    public class GetObjectionRequest : IRequest<PaginateResponse<GetObjectionDTO>>
    {
        public required PaginateRequestDTO PaginateRequest { get; set; }
    }
}
