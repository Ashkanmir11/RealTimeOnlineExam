using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveQuestionAnswers;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveQuestionAnswers.Request.Queries
{
    public class GetDescriptiveQuestionAnswersRequest : IRequest<PaginateResponse<GetDescriptiveQuestionAnswersDTO>>
    {
        public required PaginateRequestDTO PaginateRequest { get; set; }
    }
}
