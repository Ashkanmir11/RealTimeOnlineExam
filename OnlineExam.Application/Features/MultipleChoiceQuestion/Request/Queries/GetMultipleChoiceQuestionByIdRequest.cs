using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Queries
{
    public class GetMultipleChoiceQuestionByIdRequest : IRequest<GetMultipleChoiceQuestionDTO>
    {
        public int Id { get; set; }
    }
}
