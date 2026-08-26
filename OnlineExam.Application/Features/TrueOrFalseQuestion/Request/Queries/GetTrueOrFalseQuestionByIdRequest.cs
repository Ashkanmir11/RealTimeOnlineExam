using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;

namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Queries
{
    public class GetTrueOrFalseQuestionByIdRequest : IRequest<GetTrueOrFalseQuestionDTO>
    {
        public int Id { get; set; }
    }
}
