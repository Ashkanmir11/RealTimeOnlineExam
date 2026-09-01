using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Handler.Queries
{
    public class GetTrueOrFalseQuestionRequestHandler : IRequestHandler<GetTrueOrFalseQuestionRequest, PaginateResponse<GetTrueOrFalseQuestionDTO>>
    {
        private readonly ITrueOrFalseQuestionRepository _trueOrFalseQuestionRepository;
        public GetTrueOrFalseQuestionRequestHandler(ITrueOrFalseQuestionRepository trueOrFalseQuestionRepository)
        {
            _trueOrFalseQuestionRepository = trueOrFalseQuestionRepository;
        }

        public Task<PaginateResponse<GetTrueOrFalseQuestionDTO>> Handle(GetTrueOrFalseQuestionRequest request, CancellationToken cancellationToken)
        {
            return _trueOrFalseQuestionRepository.GetAllAsync<GetTrueOrFalseQuestionDTO>(request.PaginateRequest);
        }
    }
}
