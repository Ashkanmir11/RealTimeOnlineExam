using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands
{
    public class DeleteMultipleChoiceAnswerRequest : IRequest
    {
        public int Id {  get; set; }
    }
}
