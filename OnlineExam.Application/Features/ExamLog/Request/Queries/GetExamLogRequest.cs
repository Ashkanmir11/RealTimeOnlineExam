using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.ExamLog;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.ExamLog.Request.Queries
{
    public class GetExamLogRequest : IRequest<PaginateResponse<GetExamLogDTO>>
    {
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
