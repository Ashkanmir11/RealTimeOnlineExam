using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Exam.Request.Commands
{
    public class DeleteExamRequest : IRequest
    {
        public int Id { get; set; }
    }
}
