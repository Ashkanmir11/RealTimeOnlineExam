using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.Exam.Request.Queries
{
    public class GetExamRequest : IRequest<PaginateResponse<GetExamDTO>>
    {
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
