using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Commands
{
    public class DeleteMultipleChoiceQuestionRequest : IRequest
    {
        public int Id { get; set; }
    }
}
