using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Features.Exam.Request.Queries;

namespace OnlineExam.Application.Features.Exam.Handler.Queries
{
    public class GetExamSummeryRequestHandler : IRequestHandler<GetExamSummeryRequest, GetExamSummeryDTO>
    {
        private readonly IExamRepository _examRepository;
        public GetExamSummeryRequestHandler(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task<GetExamSummeryDTO> Handle(GetExamSummeryRequest request, CancellationToken cancellationToken)
        {
            return await _examRepository.GetAsync<GetExamSummeryDTO>(request.ExamId);
        }
    }
}
