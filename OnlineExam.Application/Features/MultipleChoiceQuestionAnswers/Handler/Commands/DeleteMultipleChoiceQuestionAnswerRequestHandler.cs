using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;

namespace OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Handler.Commands
{
    public class DeleteMultipleChoiceQuestionAnswerRequestHandler : IRequestHandler<DeleteMultipleChoiceQuestionAnswerRequest>
    {
        private readonly IMultipleChoiceQuestionAnswersRepository _multipleChoiceQuestionAnswersRepository;
        public DeleteMultipleChoiceQuestionAnswerRequestHandler(IMultipleChoiceQuestionAnswersRepository multipleChoiceQuestionAnswersRepository)
        {
            _multipleChoiceQuestionAnswersRepository = multipleChoiceQuestionAnswersRepository;
        }
        public async Task Handle(DeleteMultipleChoiceQuestionAnswerRequest request, CancellationToken cancellationToken)
        {
            var answer = await _multipleChoiceQuestionAnswersRepository.GetAsync(request.Id);
            if (answer == null)
            {
                throw new BadRequestException($"پاسخ با آیدی {request.Id} یافت نشد.");
            }
            await _multipleChoiceQuestionAnswersRepository.DeleteAsync(answer);
        }
    }
}
