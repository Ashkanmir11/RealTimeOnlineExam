using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.Question.Request.Queries
{
    public class GetQuestionExamStudentRequest : IRequest<PaginateResponse<GetQuestionStudentDTO>>
    {
        public int ExamId { get; set; }
        public bool RandomQuesiton { get; set; }
        public string? StudentId { get; set; }
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }

    }
}
