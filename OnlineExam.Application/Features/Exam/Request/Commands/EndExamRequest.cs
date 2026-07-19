using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Exam.Request.Commands
{
    public class EndExamRequest : IRequest
    {
        public int ExamId {  get; set; }
    }
}
