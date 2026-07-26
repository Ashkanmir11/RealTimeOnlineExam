using MediatR;
using OnlineExam.Application.DTOs.ExamLog;
using OnlineExam.Application.Features.ExamLog.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ExamLog.Request.Queries
{
    public class GetExamLogByIdRequest : IRequest<GetExamLogDTO>
    {
        public int Id { get; set; }
    }
}
