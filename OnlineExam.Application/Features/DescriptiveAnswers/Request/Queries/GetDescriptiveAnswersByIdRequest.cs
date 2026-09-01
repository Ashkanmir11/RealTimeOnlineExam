using MediatR;
using OnlineExam.Application.DTOs.DescriptiveAnswers;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Request.Queries
{
    public class GetDescriptiveAnswersByIdRequest : IRequest<GetDescriptiveAnswersDTO>
    {
        public int Id { get; set; }
    }
}
