using MediatR;
using OnlineExam.Application.DTOs.ExamLog;

namespace OnlineExam.Application.Features.ExamLog.Request.Commands
{
    public class CreateExamLogRequest : IRequest
    {
        public required CreateExamLogDTO CreateExamLogDTO { get; set; }
    }
}
