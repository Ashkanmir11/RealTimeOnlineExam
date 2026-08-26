using MediatR;
using OnlineExam.Application.DTOs.Exam;

namespace OnlineExam.Application.Features.Exam.Request.Queries
{
    public class GetExamSummeryRequest : IRequest<GetExamSummeryDTO>
    {
        public int ExamId { get; set; }
    }
}
