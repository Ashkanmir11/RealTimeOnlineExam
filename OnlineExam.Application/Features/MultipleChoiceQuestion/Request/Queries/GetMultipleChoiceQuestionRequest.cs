using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Queries
{
    public class GetMultipleChoiceQuestionRequest : IRequest<PaginateResponse<GetMultipleChoiceQuestionDTO>>
    {
       public required PaginateRequestDTO paginateRequestDTO { get; set; }
    }
}
