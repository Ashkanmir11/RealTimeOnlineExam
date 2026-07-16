using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands
{
    public class DeleteTrueOrFalseAnswerRequest : IRequest
    {
        public int Id { get; set; }
    }
}
