using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.Features.DescriptiveQuestionAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Application.Features.DescriptiveQuestionAnswers.Handler.Commands
{
    public class DeleteDescriptiveQuestionAnswersRequestHandler : IRequestHandler<DeleteDescriptiveQuestionAnswersRequest>
    {
        private readonly IDescriptiveQuestionAnswersRepository _descriptiveQuestionAnswersRepository;
        public DeleteDescriptiveQuestionAnswersRequestHandler(IDescriptiveQuestionAnswersRepository descriptiveQuestionAnswersRepository)
        {
            _descriptiveQuestionAnswersRepository = descriptiveQuestionAnswersRepository;
        }

        public async Task Handle(DeleteDescriptiveQuestionAnswersRequest request, CancellationToken cancellationToken)
        {
            var questionAnswer = await _descriptiveQuestionAnswersRepository.GetAsync(request.Id);
            if(questionAnswer == null)
            {
                throw new BadRequestException($"پاسخی با آیدی {request.Id} یافت نشد.");
            }
            await _descriptiveQuestionAnswersRepository.DeleteAsync(questionAnswer);
        }
    }
}
