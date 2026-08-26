using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Queries
{
    public class GetMyMultipleChoiceAnswerRequest : IRequest<GetMultipleChoiceAnswerStudentDTO>
    {
        public int MultipleChoiceQuestionId { get; set; }
    }
}
