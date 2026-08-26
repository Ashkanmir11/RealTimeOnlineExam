using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Queries
{
    public class GetTrueOrFalseAnswerByIdRequest : IRequest<GetTrueOrFalseAnswerDTO>
    {
        public int Id { get; set; }
    }
}
