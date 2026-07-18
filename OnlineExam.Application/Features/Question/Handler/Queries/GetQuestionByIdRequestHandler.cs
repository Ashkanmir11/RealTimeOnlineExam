using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Features.Question.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Question.Handler.Queries
{
    public class GetQuestionByIdRequestHandler : IRequestHandler<GetQuestionByIdRequest, GetQuestionDTO>
    {
        private readonly IQuestionRepository _questionRepository;
        public GetQuestionByIdRequestHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<GetQuestionDTO> Handle(GetQuestionByIdRequest request, CancellationToken cancellationToken)
        {
            return await _questionRepository.GetAsync<GetQuestionDTO>(request.Id);
        }
    }
}
