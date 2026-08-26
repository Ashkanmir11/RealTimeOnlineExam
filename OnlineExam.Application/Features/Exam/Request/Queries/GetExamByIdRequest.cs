using MediatR;
using OnlineExam.Application.DTOs.Exam;

namespace OnlineExam.Application.Features.Exam.Request.Queries
{
    public class GetExamByIdRequest : IRequest<GetExamDTO>
    {
        public int Id { get; set; }
    }
}
