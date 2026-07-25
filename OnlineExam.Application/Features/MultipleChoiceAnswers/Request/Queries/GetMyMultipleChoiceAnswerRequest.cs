using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Queries
{
    public class GetMyMultipleChoiceAnswerRequest : IRequest<GetMultipleChoiceAnswerStudentDTO>
    {
        public int MultipleChoiceQuestionId {  get; set; }
    }
}
