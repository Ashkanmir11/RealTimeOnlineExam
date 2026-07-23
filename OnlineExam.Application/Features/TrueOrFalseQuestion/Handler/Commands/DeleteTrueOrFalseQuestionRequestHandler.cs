using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
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
            if(question==null)
            {
                throw new NotFoundException($"سوالی با آیدی {request.Id} یافت نشد.");
            }
            await _trueOrFalseQuestionRepository.DeleteAsync(question);
        }
    }
}
