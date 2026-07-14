using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Commands
{
    public class UpdateMultipleChoiceQuestionRequest : IRequest
    {
        public required UpdateMultipleChoiceQuestionDTO UpdateMultipleChoiceQuestionDTO { get; set; }
    }
}
