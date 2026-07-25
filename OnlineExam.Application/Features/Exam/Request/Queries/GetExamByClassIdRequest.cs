using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Exam.Request.Queries
{
    public class GetExamByClassIdRequest : IRequest<PaginateResponse<GetExamDetailDTO>>
    {
        public int ClassId {  get; set; }
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
