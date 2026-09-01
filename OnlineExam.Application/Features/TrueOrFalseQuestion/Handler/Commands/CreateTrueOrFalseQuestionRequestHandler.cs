using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Commands;

namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Handler.Commands
{
    public class CreateTrueOrFalseQuestionRequestHandler : IRequestHandler<CreateTrueOrFalseQuestionRequest, int>
    {
        private readonly ITrueOrFalseQuestionRepository _trueOrFalseQuestionRepository;
        public CreateTrueOrFalseQuestionRequestHandler(ITrueOrFalseQuestionRepository trueOrFalseQuestionRepository)
        {
            _trueOrFalseQuestionRepository = trueOrFalseQuestionRepository;
        }

        public async Task<int> Handle(CreateTrueOrFalseQuestionRequest request, CancellationToken cancellationToken)
        {
            var result = await _trueOrFalseQuestionRepository.AddAsync(request.CreateTrueOrFalseQuestionDTO);
            return result.Id;
        }
    }
}
