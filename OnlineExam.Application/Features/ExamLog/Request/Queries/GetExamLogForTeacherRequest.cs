using MediatR;
using OnlineExam.Application.DTOs.ExamLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ExamLog.Request.Queries
{
    public class GetExamLogForTeacherRequest : IRequest<List<GetExamLogDTO>>
    {
        public required int ExamId {  get; set; }
        public required string StudentId {  get; set; }
    }
}
