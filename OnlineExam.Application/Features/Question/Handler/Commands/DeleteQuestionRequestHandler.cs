using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.Question.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Application.Features.Question.Handler.Commands
{
    public class DeleteQuestionRequestHandler : IRequestHandler<DeleteQuestionRequest>
    {
        private readonly IQuestionRepository _questionRepository;
        public DeleteQuestionRequestHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task Handle(DeleteQuestionRequest request, CancellationToken cancellationToken)
        {
            var qeustion = await _questionRepository.GetAsync(request.Id);
            if (qeustion == null)
            {
                throw new NotFoundException($"سوالی با آیدی {request.Id} یافت نشد.");
            }
            await _questionRepository.DeleteQuestionDetailAsync(request.Id);
            await _questionRepository.DeleteAsync(qeustion);
        }
    }
}
