using MediatR;
using OnlineExam.Application.DTOs.DescriptiveAnswers;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Request.Queries
{
    public class GetMyDescriptiveAnswerRequest : IRequest<GetDescriptiveAnswerStudentDTO>
    {
        public int descriptiveQuestionId { get; set; }
    }
}
