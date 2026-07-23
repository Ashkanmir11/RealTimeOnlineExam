using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.DescriptiveQuestion.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (question==null)
            {
                throw new NotFoundException($"سوال با آیدی {request.Id} یافت نشد.");
            }
            await _descriptiveQuestionRepository.DeleteAsync(question);
        }
    }
}
