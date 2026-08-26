using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.DescriptiveQuestion.Request.Commands;

namespace OnlineExam.Application.Features.DescriptiveQuestion.Handler.Commands
{
    public class DeleteDescriptiveQuestionRequestHandler : IRequestHandler<DeleteDescriptiveQuestionRequest>
    {
        private readonly IDescriptiveQuestionRepository _descriptiveQuestionRepository;
        public DeleteDescriptiveQuestionRequestHandler(IDescriptiveQuestionRepository descriptiveQuestionRepository)
        {
            _descriptiveQuestionRepository = descriptiveQuestionRepository;
        }

        public async Task Handle(DeleteDescriptiveQuestionRequest request, CancellationToken cancellationToken)
        {
            var question = await _descriptiveQuestionRepository.GetAsync(request.Id);
            if (question == null)
            {
                throw new NotFoundException($"سوال با آیدی {request.Id} یافت نشد.");
            }
            await _descriptiveQuestionRepository.DeleteAsync(question);
        }
    }
}
