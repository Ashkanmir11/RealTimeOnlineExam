using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Queries
{
    public class GetTrueOrFalseQuestionRequest : IRequest<PaginateResponse<GetTrueOrFalseQuestionDTO>>
    {
        public required PaginateRequestDTO PaginateRequest { get; set; }
    }
}
