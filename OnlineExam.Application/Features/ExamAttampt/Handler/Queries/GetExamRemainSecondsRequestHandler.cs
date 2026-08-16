using MediatR;
using Newtonsoft.Json.Serialization;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.ExamAttampt.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await _examAttamptRepository.GetRemainingSeconds(request.ExamId , request.currentUser);
        }
    }
}
