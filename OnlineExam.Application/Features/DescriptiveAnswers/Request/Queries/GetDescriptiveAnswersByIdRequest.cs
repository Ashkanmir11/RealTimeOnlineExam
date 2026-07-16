using MediatR;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Request.Queries
{
    public class GetDescriptiveAnswersByIdRequest : IRequest<GetDescriptiveAnswersDTO>
    {
        public int Id { get; set; }
    }
}
