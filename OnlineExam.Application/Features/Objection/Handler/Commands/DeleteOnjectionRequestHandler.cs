using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.Objection.Request.Commands;
namespace OnlineExam.Application.Features.Objection.Handler.Commands
{
    public class DeleteOnjectionRequestHandler : IRequestHandler<DeleteOnjectionRequest>
    {
        private readonly IObjectionRepository _objectionRepository;
        public DeleteOnjectionRequestHandler(IObjectionRepository objectionRepository)
        {
            _objectionRepository = objectionRepository;
        }

        public async Task Handle(DeleteOnjectionRequest request, CancellationToken cancellationToken)
        {
            var objection = await _objectionRepository.GetAsync(request.Id);
            if (objection == null)
            {
                throw new NotFoundException($"آیدی {request.Id} یافت نشد.");
            }
            await _objectionRepository.DeleteAsync(objection);
        }
    }
}
