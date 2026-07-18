using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Features.Question.Request.Queries;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Question.Handler.Queries
{
    public class GetQuestionForExamRequestHandler : IRequestHandler<GetQuestionForExamRequest, PaginateResponse<GetQuestionDTO>>
    {
        private readonly IQuestionRepository _questionRepository;
        public GetQuestionForExamRequestHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<PaginateResponse<GetQuestionDTO>> Handle(GetQuestionForExamRequest request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            return await _questionRepository.GetByExamId(request.ExamId, request.RandomQuesiton,request.StudentId,request.PaginateRequestDTO);
        }
    }
}
