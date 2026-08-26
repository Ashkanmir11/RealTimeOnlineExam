using MediatR;

namespace OnlineExam.Application.Features.LogType.Reqeust.Commands
{
    public class DeleteLogTypeRequest : IRequest
    {
        public int Id { get; set; }
    }
}
