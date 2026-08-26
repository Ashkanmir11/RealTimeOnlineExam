using MediatR;
using OnlineExam.Application.DTOs.ExamLog;

namespace OnlineExam.Application.Features.ExamLog.Request.Queries
{
    public class GetExamLogByIdRequest : IRequest<GetExamLogDTO>
    {
        public int Id { get; set; }
    }
}
