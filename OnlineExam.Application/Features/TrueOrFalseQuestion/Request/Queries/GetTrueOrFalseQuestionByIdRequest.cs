using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Queries
{
    public class GetTrueOrFalseQuestionByIdRequest : IRequest<GetTrueOrFalseQuestionDTO>
    {
        public int Id { get; set; }
    }
}
