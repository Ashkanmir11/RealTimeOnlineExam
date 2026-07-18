using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ExamAttampt.Request.Queries
{
    public class ExamAttamptEndedRequest:IRequest<bool>
    {
        public int ExamId {  get; set; }
        public required string UserId {  get; set; }
    }
}
