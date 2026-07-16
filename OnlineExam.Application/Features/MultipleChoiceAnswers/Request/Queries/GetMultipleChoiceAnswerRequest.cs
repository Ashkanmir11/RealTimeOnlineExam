using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Queries
{
    public class GetMultipleChoiceAnswerRequest:IRequest<PaginateResponse<GetMultipleChoiceAnswerDTO>>
    {
        public required PaginateRequestDTO PaginateRequest { get; set; }
    }
}
