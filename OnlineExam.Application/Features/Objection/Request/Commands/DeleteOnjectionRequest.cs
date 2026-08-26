using MediatR;

namespace OnlineExam.Application.Features.Objection.Request.Commands
{
    public class DeleteOnjectionRequest : IRequest
    {
        public int Id { get; set; }
    }
}
