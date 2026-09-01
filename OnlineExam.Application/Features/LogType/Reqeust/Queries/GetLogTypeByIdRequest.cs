using MediatR;
using OnlineExam.Application.DTOs.LogType;

namespace OnlineExam.Application.Features.LogType.Reqeust.Queries
{
    public class GetLogTypeByIdRequest : IRequest<GetLogTypeDTO>
    {
        public int Id { get; set; }
    }
}
