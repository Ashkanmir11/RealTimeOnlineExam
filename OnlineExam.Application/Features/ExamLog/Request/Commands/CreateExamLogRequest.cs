using MediatR;
using OnlineExam.Application.DTOs.ExamLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ExamLog.Request.Commands
{
    public class CreateExamLogRequest : IRequest
    {
        public required CreateExamLogDTO CreateExamLogDTO { get; set; }
    }
}
