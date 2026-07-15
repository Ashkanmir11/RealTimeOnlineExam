using MediatR;
using OnlineExam.Application.DTOs.DescriptiveQuestionAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveQuestionAnswers.Request.Commands
{
    public class CreateDescriptiveQuestionAnswersRequest : IRequest
    {
        public required CreateDescriptiveQuestionAnswersDTO CreateDescriptiveQuestionAnswersDTO { get; set; }
    }
}
