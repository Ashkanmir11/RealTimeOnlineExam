using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Queries;

namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Handler.Queries
{
    public class GetTrueOrFalseQuestionByIdRequestHandler : IRequestHandler<GetTrueOrFalseQuestionByIdRequest, GetTrueOrFalseQuestionDTO>
    {
        private readonly ITrueOrFalseQuestionRepository _trueOrFalseQuestionRepository;
        public GetTrueOrFalseQuestionByIdRequestHandler(ITrueOrFalseQuestionRepository trueOrFalseQuestionRepository)
        {
            _trueOrFalseQuestionRepository = trueOrFalseQuestionRepository;
        }
        public async Task<GetTrueOrFalseQuestionDTO> Handle(GetTrueOrFalseQuestionByIdRequest request, CancellationToken cancellationToken)
        {
            return await _trueOrFalseQuestionRepository.GetAsync<GetTrueOrFalseQuestionDTO>(request.Id);
        }
    }
}
