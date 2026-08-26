using MediatR;
using OnlineExam.Application.DTOs.Objection;

namespace OnlineExam.Application.Features.Objection.Request.Commands
{
    public class CreateObjectionReqeust : IRequest
    {
        public required CreateObjectionDTO CreateObjectionDTO { get; set; }
    }
}
