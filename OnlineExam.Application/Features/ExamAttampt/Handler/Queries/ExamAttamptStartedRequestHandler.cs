using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.ExamAttampt.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ExamAttampt.Handler.Queries
{
    public class ExamAttamptStartedRequestHandler : IRequestHandler<ExamAttamptStartedRequest, bool>
    {
        private readonly IExamAttamptRepository _examAttamptRepository;
        public ExamAttamptStartedRequestHandler(IExamAttamptRepository examAttamptRepository)
        {
            _examAttamptRepository = examAttamptRepository;
        }

        public async Task<bool> Handle(ExamAttamptStartedRequest request, CancellationToken cancellationToken)
        {
           return await _examAttamptRepository.ExamStartedAsync(request.ExamId, request.UserId);
        }
    }
}
