using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Handler.Commands
{
    public class DeleteTrueOrFalseAnswerRequestHandler : IRequestHandler<DeleteTrueOrFalseAnswerRequest>
    {
        private readonly ITrueOrFalseAnswersRepository _TrueOrFalseAnswersRepository;
        public DeleteTrueOrFalseAnswerRequestHandler(ITrueOrFalseAnswersRepository TrueOrFalseAnswersRepository)
        {
            _TrueOrFalseAnswersRepository = TrueOrFalseAnswersRepository;
        }
        public async Task Handle(DeleteTrueOrFalseAnswerRequest request, CancellationToken cancellationToken)
        {
            var answer = await _TrueOrFalseAnswersRepository.GetAsync(request.Id);
            if(answer==null)
            {
                throw new BadRequestException($"پاسخی با آیدی {request.Id} .یافت نشد");
            }
            await _TrueOrFalseAnswersRepository.DeleteAsync(answer);
        }
    }
}
