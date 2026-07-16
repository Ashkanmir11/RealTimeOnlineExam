using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Handler.Commands
{
    public class DeleteMultipleChoiceAnswerRequestHandler : IRequestHandler<DeleteMultipleChoiceAnswerRequest>
    {
        private readonly IMultipleChoiceAnswersRepository _MultipleChoiceAnswersRepository;
        public DeleteMultipleChoiceAnswerRequestHandler(IMultipleChoiceAnswersRepository MultipleChoiceAnswersRepository)
        {
            _MultipleChoiceAnswersRepository = MultipleChoiceAnswersRepository;
        }
        public async Task Handle(DeleteMultipleChoiceAnswerRequest request, CancellationToken cancellationToken)
        {
            var answer = await _MultipleChoiceAnswersRepository.GetAsync(request.Id);
            if (answer == null)
            {
                throw new BadRequestException($"پاسخ با آیدی {request.Id} یافت نشد.");
            }
            await _MultipleChoiceAnswersRepository.DeleteAsync(answer);
        }
    }
}
