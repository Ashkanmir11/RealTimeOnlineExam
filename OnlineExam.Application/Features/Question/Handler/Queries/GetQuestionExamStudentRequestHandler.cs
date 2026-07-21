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
    public class GetQuestionExamStudentRequestHandler : IRequestHandler<GetQuestionExamStudentRequest, PaginateResponse<GetQuestionStudentDTO>>
    {
        private readonly IQuestionRepository _questionRepository;
        public GetQuestionExamStudentRequestHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<PaginateResponse<GetQuestionStudentDTO>> Handle(GetQuestionExamStudentRequest request, CancellationToken cancellationToken)
        {
            return await _questionRepository.GetByExamIdAsync<GetQuestionStudentDTO>(request.ExamId, request.RandomQuesiton,request.StudentId,request.PaginateRequestDTO);
        }
    }
}
