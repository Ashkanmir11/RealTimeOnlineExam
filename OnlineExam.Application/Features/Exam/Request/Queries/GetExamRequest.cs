using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Helper;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Exam.Request.Queries
{
    public class GetExamRequest : IRequest<PaginateResponse<GetExamDTO>>
    {
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
