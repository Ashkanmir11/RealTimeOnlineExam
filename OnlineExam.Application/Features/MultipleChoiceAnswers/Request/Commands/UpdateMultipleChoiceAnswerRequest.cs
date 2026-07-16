using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands
{
    public class UpdateMultipleChoiceAnswerRequest : IRequest
    {
        public required UpdateMultipleChoiceAnswerDTO UpdateMultipleChoiceQuestionAnswerDTO { get; set; }
    }
}
