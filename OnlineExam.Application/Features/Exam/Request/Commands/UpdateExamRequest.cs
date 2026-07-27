using MediatR;
using OnlineExam.Application.DTOs.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Exam.Request.Commands
{
    public class UpdateExamRequest: IRequest
    {
        public int Id {  get; set; }
        public required UpdateExamDTO UpdateExamDTO { get; set; }
    }
}
