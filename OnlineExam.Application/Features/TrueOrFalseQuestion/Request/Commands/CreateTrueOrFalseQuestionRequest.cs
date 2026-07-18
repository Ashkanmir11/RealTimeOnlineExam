using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Commands
{
    public class CreateTrueOrFalseQuestionRequest : IRequest<int>
    {
        public required CreateTrueOrFalseQuestionDTO CreateTrueOrFalseQuestionDTO { get; set; }
    }
}
