using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Queries
{
    public class GetMultipleChoiceAnswerByIdRequest : IRequest<GetMultipleChoiceAnswerDTO>
    {
        public int Id { get; set; }
    }
}
