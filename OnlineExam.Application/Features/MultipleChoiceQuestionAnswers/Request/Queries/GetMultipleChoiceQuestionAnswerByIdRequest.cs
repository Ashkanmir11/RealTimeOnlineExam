using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Request.Queries
{
    public class GetMultipleChoiceQuestionAnswerByIdRequest : IRequest<GetMultipleChoiceQuestionAnswerDTO>
    {
        public int Id { get; set; }
    }
}
