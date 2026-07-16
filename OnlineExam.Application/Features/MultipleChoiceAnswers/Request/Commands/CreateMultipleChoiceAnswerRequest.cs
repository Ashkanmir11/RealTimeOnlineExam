using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands
{
    public class CreateMultipleChoiceAnswerRequest : IRequest
    {
        public required CreateMultipleChoiceAnswerDTO CreateMultipleChoiceQuestionAnswerDTO { get; set; }
    }
}
