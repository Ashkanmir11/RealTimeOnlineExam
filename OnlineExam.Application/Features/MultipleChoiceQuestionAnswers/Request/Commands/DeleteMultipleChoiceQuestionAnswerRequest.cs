using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Request.Commands
{
    public class DeleteMultipleChoiceQuestionAnswerRequest : IRequest
    {
        public int Id {  get; set; }
    }
}
