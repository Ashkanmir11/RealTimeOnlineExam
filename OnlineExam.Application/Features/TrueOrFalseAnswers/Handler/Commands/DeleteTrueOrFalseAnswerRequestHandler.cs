using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands;
namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Handler.Commands
{
    public class DeleteTrueOrFalseAnswerRequestHandler : IRequestHandler<DeleteTrueOrFalseAnswerRequest>
    {
        private readonly ITrueOrFalseAnswersRepository _TrueOrFalseAnswersRepository;
        private readonly IAuthServices _authServices;
        public DeleteTrueOrFalseAnswerRequestHandler(ITrueOrFalseAnswersRepository TrueOrFalseAnswersRepository, IAuthServices authServices)
        {
            _TrueOrFalseAnswersRepository = TrueOrFalseAnswersRepository;
            _authServices = authServices;
        }
        public async Task Handle(DeleteTrueOrFalseAnswerRequest request, CancellationToken cancellationToken)
        {
            var answer = await _TrueOrFalseAnswersRepository.GetAsync(request.Id);
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var isAdmin = await _authServices.IsUserAdminAsync(currentUser);
            var questionAnswer = await _TrueOrFalseAnswersRepository.GetAsync(request.Id);
            if (answer == null)
            {
                throw new NotFoundException($"پاسخی با آیدی {request.Id} .یافت نشد");
            }
            if (questionAnswer.StudentId != currentUser && !isAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی این عملیات را ندارید.");
            }


            await _TrueOrFalseAnswersRepository.DeleteAsync(answer);
        }
    }
}
