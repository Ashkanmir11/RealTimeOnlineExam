using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Commands;
namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Handler.Commands
{
    public class DeleteTrueOrFalseQuestionRequestHandler : IRequestHandler<DeleteTrueOrFalseQuestionRequest>
    {
        private readonly ITrueOrFalseQuestionRepository _trueOrFalseQuestionRepository;
        public DeleteTrueOrFalseQuestionRequestHandler(ITrueOrFalseQuestionRepository trueOrFalseQuestionRepository)
        {
            _trueOrFalseQuestionRepository = trueOrFalseQuestionRepository;
        }
        public async Task Handle(DeleteTrueOrFalseQuestionRequest request, CancellationToken cancellationToken)
        {
            var question = await _trueOrFalseQuestionRepository.GetAsync(request.Id);
            if (question == null)
            {
                throw new NotFoundException($"سوالی با آیدی {request.Id} یافت نشد.");
            }
            await _trueOrFalseQuestionRepository.DeleteAsync(question);
        }
    }
}
