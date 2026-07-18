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
    public class GetQuestionRequestHandler : IRequestHandler<GetQuestionRequest, PaginateResponse<GetQuestionDTO>>
    {
        private readonly IQuestionRepository _questionRepository;
        public GetQuestionRequestHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<PaginateResponse<GetQuestionDTO>> Handle(GetQuestionRequest request, CancellationToken cancellationToken)
        {
            return await _questionRepository.GetAllAsync<GetQuestionDTO>(request.PaginateRequest);
        }
    }
}
