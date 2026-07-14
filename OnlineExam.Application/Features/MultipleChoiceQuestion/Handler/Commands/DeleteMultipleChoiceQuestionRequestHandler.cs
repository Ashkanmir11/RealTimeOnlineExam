using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Handler.Commands
{
    public class DeleteMultipleChoiceQuestionRequestHandler : IRequestHandler<DeleteMultipleChoiceQuestionRequest>
    {
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;
        public DeleteMultipleChoiceQuestionRequestHandler(IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository)
        {
            _multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
        }

        public async Task Handle(DeleteMultipleChoiceQuestionRequest request, CancellationToken cancellationToken)
        {
            var question = await _multipleChoiceQuestionRepository.GetAsync(request.Id);
            if(question==null)
            {
                throw new BadRequestException($"سوال با آیدی {request.Id} یافت نشد.");
            }
            await _multipleChoiceQuestionRepository.DeleteAsync(question);

        }
    }
}
