using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands
{
    public class UpdateTrueOrFalseAnswerRequest : IRequest
    {
        public required UpdateTrueOrFalseAnswerDTO UpdateTrueOrFalseQuestionAnswerDTO { get; set; }
    }
}
