using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Request.Commands
{
    public class CreateMultipleChoiceQuestionAnswerRequest : IRequest
    {
        public required CreateMultipleChoiceQuestionAnswerDTO CreateMultipleChoiceQuestionAnswerDTO { get; set; }
    }
}
