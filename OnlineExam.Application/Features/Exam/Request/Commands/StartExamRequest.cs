using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Exam.Request.Commands
{
    public class StartExamRequest : IRequest<PaginateResponse<GetQuestionDTO>>
    {

        public int ExamId {  get; set; }
        public required PaginateRequestDTO paginateRequestDTO { get; set; }
    }
}
