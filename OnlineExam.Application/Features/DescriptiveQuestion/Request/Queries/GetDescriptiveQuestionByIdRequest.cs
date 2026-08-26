using MediatR;
using OnlineExam.Application.DTOs.DescriptiveQuestion;

namespace OnlineExam.Application.Features.DescriptiveQuestion.Request.Queries
{
    public class GetDescriptiveQuestionByIdRequest : IRequest<GetDescriptiveQuestionDTO>
    {
        public int Id { get; set; }
    }
}
