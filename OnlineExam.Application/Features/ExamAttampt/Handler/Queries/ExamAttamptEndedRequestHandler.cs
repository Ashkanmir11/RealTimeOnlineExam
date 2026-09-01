using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.ExamAttampt.Request.Queries;

namespace OnlineExam.Application.Features.ExamAttampt.Handler.Queries
{
    public class ExamAttamptEndedRequestHandler : IRequestHandler<ExamAttamptEndedRequest, bool>
    {
        private readonly IExamAttamptRepository _examAttamptRepository;
        public ExamAttamptEndedRequestHandler(IExamAttamptRepository examAttamptRepository)
        {
            _examAttamptRepository = examAttamptRepository;
        }

        public async Task<bool> Handle(ExamAttamptEndedRequest request, CancellationToken cancellationToken)
        {
            return await _examAttamptRepository.ExamEndedAsync(request.ExamId, request.UserId);
        }
    }
}
