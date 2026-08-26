using MediatR;
using OnlineExam.Application.DTOs.Objection;

namespace OnlineExam.Application.Features.Objection.Request.Commands
{
    public class UpdateObjectionRequest : IRequest
    {
        public int Id { get; set; }
        public required UpdateObjectionDTO UpdateObjectionDTO { get; set; }
    }
}
