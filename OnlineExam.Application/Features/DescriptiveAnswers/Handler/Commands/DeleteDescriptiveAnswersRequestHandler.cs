using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Application.Features.DescriptiveAnswers.Handler.Commands
{
    public class DeleteDescriptiveAnswersRequestHandler : IRequestHandler<DeleteDescriptiveAnswersRequest>
    {
        private readonly IDescriptiveAnswersRepository _DescriptiveAnswersRepository;
        public DeleteDescriptiveAnswersRequestHandler(IDescriptiveAnswersRepository DescriptiveAnswersRepository)
        {
            _DescriptiveAnswersRepository = DescriptiveAnswersRepository;
        }

        public async Task Handle(DeleteDescriptiveAnswersRequest request, CancellationToken cancellationToken)
        {
            var questionAnswer = await _DescriptiveAnswersRepository.GetAsync(request.Id);
            if(questionAnswer == null)
            {
                throw new BadRequestException($"پاسخی با آیدی {request.Id} یافت نشد.");
            }
            await _DescriptiveAnswersRepository.DeleteAsync(questionAnswer);
        }
    }
}
