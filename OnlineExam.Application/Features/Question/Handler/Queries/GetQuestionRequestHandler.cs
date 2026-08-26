using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Features.Question.Request.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.Question.Handler.Queries
{
    public class GetQuestionRequestHandler : IRequestHandler<GetQuestionRequest, PaginateResponse<GetQuestionTeacherDTO>>
    {
        private readonly IQuestionRepository _questionRepository;
        public GetQuestionRequestHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<PaginateResponse<GetQuestionTeacherDTO>> Handle(GetQuestionRequest request, CancellationToken cancellationToken)
        {
            return await _questionRepository.GetAllAsync<GetQuestionTeacherDTO>(request.PaginateRequest);
        }
    }
}
