using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Commands
{
    public class UpdateTrueOrFalseQuestionRequest : IRequest
    {
        public required UpdateTrueOfFalseQuestionDTO UpdateTrueOfFalseQuestionDTO { get; set; }
    }
}
