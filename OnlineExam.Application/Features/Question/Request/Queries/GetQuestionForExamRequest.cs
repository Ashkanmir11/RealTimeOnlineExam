using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Question.Request.Queries
{
    public class GetQuestionForExamRequest : IRequest<PaginateResponse<GetQuestionDTO>>
    {
        public int ExamId {  get; set; }
        public bool RandomQuesiton {  get; set; }
        public string? StudentId {  get; set; }
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
