using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ExamAttampt.Request.Queries
{
    public class GetExamRemainSecondsRequest : IRequest<double>
    {
        public int ExamId { get; set; }
        public required string? currentUser { get; set; }
    }
}
