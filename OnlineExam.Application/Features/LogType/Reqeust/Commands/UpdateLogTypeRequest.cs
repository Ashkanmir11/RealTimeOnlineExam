using MediatR;
using OnlineExam.Application.DTOs.LogType;

namespace OnlineExam.Application.Features.LogType.Reqeust.Commands
{
    public class UpdateLogTypeRequest : IRequest
    {
        public int Id { get; set; }
        public required UpdateLogTypeDTO UpdateLogTypeDTO { get; set; }
    }
}
