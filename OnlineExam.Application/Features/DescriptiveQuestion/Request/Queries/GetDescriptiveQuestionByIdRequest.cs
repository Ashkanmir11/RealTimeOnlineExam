using MediatR;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveQuestion.Request.Queries
{
    public class GetDescriptiveQuestionByIdRequest : IRequest<GetDescriptiveQuestionDTO>
    {
        public int Id { get; set; }
    }
}
