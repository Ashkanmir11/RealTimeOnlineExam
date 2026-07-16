using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseQuestionAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Request.Commands
{
    public class CreateTrueOrFalseQuestionAnswerRequest : IRequest
    {
        public required CreateTrueOrFalseQuestionAnswerDTO CreateTrueOrFalseQuestionAnswerDTO { get; set; }
    }
}
