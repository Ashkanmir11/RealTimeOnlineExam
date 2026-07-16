using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Request.Queries
{
    public class GetMultipleChoiceQuestionAnswerRequest:IRequest<PaginateResponse<GetMultipleChoiceQuestionAnswerDTO>>
    {
        public required PaginateRequestDTO PaginateRequest { get; set; }
    }
}
