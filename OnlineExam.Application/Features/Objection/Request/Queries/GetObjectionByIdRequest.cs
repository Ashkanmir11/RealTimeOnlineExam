using MediatR;
using OnlineExam.Application.DTOs.Objection;

namespace OnlineExam.Application.Features.Objection.Request.Queries
{
    public class GetObjectionByIdRequest : IRequest<GetObjectionDTO>
    {
        public int Id { get; set; }
    }
}
