using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.ExamAttampt.Request.Queries;

namespace OnlineExam.Application.Features.ExamAttampt.Handler.Queries
{
    public class GetExamRemainSecondsRequestHandler : IRequestHandler<GetExamRemainSecondsRequest, double>
    {
        private readonly IExamAttamptRepository _examAttamptRepository;
        public GetExamRemainSecondsRequestHandler(IExamAttamptRepository examAttamptRepository)
        {
            _examAttamptRepository = examAttamptRepository;
        }

        public async Task<double> Handle(GetExamRemainSecondsRequest request, CancellationToken cancellationToken)
        {
            return await _examAttamptRepository.GetRemainingSeconds(request.ExamId, request.currentUser);
        }
    }
}
