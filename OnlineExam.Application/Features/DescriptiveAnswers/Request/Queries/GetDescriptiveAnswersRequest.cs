using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Request.Queries
{
    public class GetDescriptiveAnswersRequest : IRequest<PaginateResponse<GetDescriptiveAnswersDTO>>
    {
        public required PaginateRequestDTO PaginateRequest { get; set; }
    }
}
