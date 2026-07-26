using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.ExamLog;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ExamLog.Request.Queries
{
    public class GetExamLogRequest : IRequest<PaginateResponse<GetExamLogDTO>>
    {
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
