using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveQuestion.Request.Queries
{
    public class GetDescriptiveQuestionRequest : IRequest<PaginateResponse<GetDescriptiveQuestionDTO>>
    {
        public required PaginateRequestDTO PaginateRequest { get; set; }
    }
}
