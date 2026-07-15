using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveQuestionAnswers.Request.Commands
{
    public class DeleteDescriptiveQuestionAnswersRequest : IRequest
    {
        public int Id { get; set; }
    }
}
