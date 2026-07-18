using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Question.Request.Commands
{
    public class DeleteQuestionRequest : IRequest
    {
        public int Id { get; set; }
    }
}
