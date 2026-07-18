using MediatR;
using OnlineExam.Application.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Question.Request.Commands
{
    public class UpdateQuestionRequest : IRequest
    {
        public required UpdateQuestionDTO UpdateQuestionDTO { get; set; }
    }
}
