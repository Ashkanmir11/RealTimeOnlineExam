using MediatR;
using OnlineExam.Application.DTOs.LogType;

namespace OnlineExam.Application.Features.LogType.Reqeust.Commands
{
    public class CreateLogTypeRequest : IRequest
    {
        public required CreateLogTypeDTO CreateLogTypeDTO { get; set; }
    }
}
