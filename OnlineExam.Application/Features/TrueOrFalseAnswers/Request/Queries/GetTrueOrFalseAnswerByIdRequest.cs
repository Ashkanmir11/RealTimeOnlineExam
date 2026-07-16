using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Queries
{
    public class GetTrueOrFalseAnswerByIdRequest:IRequest<GetTrueOrFalseAnswerDTO>
    {
        public int Id { get; set; }
    }
}
