using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands
{
    public class DeleteDescriptiveAnswersRequest : IRequest
    {
        public int Id { get; set; }
    }
}
