using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Queries
{
    public class GetMyTrueOrFalseAnswerRequest : IRequest<GetTrueOrFalseAnswerStudentDTO>
    {
        public int TrueOrFalseQuestionId { get; set; }
    }
}
