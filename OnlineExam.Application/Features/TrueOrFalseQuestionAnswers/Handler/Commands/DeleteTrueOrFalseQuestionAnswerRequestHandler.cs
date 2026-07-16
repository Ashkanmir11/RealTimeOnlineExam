using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Handler.Commands
{
    public class DeleteTrueOrFalseQuestionAnswerRequestHandler : IRequestHandler<DeleteTrueOrFalseQuestionAnswerRequest>
    {
        private readonly ITrueOrFalseQuestionAnswersRepository _trueOrFalseQuestionAnswersRepository;
        public DeleteTrueOrFalseQuestionAnswerRequestHandler(ITrueOrFalseQuestionAnswersRepository trueOrFalseQuestionAnswersRepository)
        {
            _trueOrFalseQuestionAnswersRepository = trueOrFalseQuestionAnswersRepository;
        }
        public async Task Handle(DeleteTrueOrFalseQuestionAnswerRequest request, CancellationToken cancellationToken)
        {
            var answer = await _trueOrFalseQuestionAnswersRepository.GetAsync(request.Id);
            if(answer==null)
            {
                throw new BadRequestException($"پاسخی با آیدی {request.Id} .یافت نشد");
            }
            await _trueOrFalseQuestionAnswersRepository.DeleteAsync(answer);
        }
    }
}
