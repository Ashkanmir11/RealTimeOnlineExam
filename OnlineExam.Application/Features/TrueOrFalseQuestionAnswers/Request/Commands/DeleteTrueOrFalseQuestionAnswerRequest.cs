using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Request.Commands
{
    public class DeleteTrueOrFalseQuestionAnswerRequest : IRequest
    {
        public int Id { get; set; }
    }
}
