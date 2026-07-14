using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveQuestion.Request.Commands
{
    public class DeleteDescriptiveQuestionRequest : IRequest
    {
        public int Id { get; set; }
    }
}
