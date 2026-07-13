using MediatR;
using OnlineExam.Application.DTOs.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Exam.Request.Queries
{
    public class GetExamByIdRequest : IRequest<GetExamDTO>
    {
        public int Id { get; set; }
    }
}
