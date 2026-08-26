using MediatR;
using OnlineExam.Application.DTOs.Question;

namespace OnlineExam.Application.Features.Question.Request.Queries
{
    public class GetQuestionByIdRequest : IRequest<GetQuestionTeacherDTO>
    {
        public int Id { get; set; }
    }
}
