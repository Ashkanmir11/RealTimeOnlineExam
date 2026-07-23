using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Contracts.Identity;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Handler.Commands
{
    public class DeleteMultipleChoiceAnswerRequestHandler : IRequestHandler<DeleteMultipleChoiceAnswerRequest>
    {
        private readonly IMultipleChoiceAnswersRepository _MultipleChoiceAnswersRepository;
        private readonly IAuthServices _authServices;
        public DeleteMultipleChoiceAnswerRequestHandler(IMultipleChoiceAnswersRepository MultipleChoiceAnswersRepository, IAuthServices authServices)
        {
            _MultipleChoiceAnswersRepository = MultipleChoiceAnswersRepository;
            _authServices = authServices;
        }
        public async Task Handle(DeleteMultipleChoiceAnswerRequest request, CancellationToken cancellationToken)
        {
            var answer = await _MultipleChoiceAnswersRepository.GetAsync(request.Id);

            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var isAdmin = await _authServices.IsUserAdminAsync(currentUser);

            if (answer.StudentId != currentUser && !isAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی این عملیات را ندارید.");
            }


            if (answer == null)
            {
                throw new NotFoundException($"پاسخ با آیدی {request.Id} یافت نشد.");
            }
            await _MultipleChoiceAnswersRepository.DeleteAsync(answer);
        }
    }
}
