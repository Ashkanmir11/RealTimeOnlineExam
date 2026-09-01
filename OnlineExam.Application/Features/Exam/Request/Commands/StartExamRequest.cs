using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.Exam.Request.Commands
{
    public class StartExamRequest : IRequest<PaginateResponse<GetQuestionStudentDTO>>
    {

        public int ExamId { get; set; }
        public required PaginateRequestDTO paginateRequestDTO { get; set; }
    }
}
