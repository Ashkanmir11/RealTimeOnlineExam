using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.Question.Request.Commands;
namespace OnlineExam.Application.Features.Question.Handler.Commands
{
    public class DeleteQuestionRequestHandler : IRequestHandler<DeleteQuestionRequest>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAuthServices _authServices;
        private readonly IExamRepository _examRepository;
        public DeleteQuestionRequestHandler(IQuestionRepository questionRepository, IAuthServices authServices, IExamRepository examRepository)
        {
            _questionRepository = questionRepository;
            _authServices = authServices;
            _examRepository = examRepository;
        }
        public async Task Handle(DeleteQuestionRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var question = await _questionRepository.GetAsync(request.Id);
            bool isTeacher = await _examRepository.IsUserTeacherAsync(currentUser, question.ExamId);
            bool isAdmin = await _authServices.IsUserAdminAsync(currentUser);

            if (!isTeacher && !isAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی به این عملیات ندارید.");
            }
            if (question == null)
            {
                throw new NotFoundException($"سوالی با آیدی {request.Id} یافت نشد.");
            }
            await _questionRepository.DeleteQuestionDetailAsync(request.Id);
            await _questionRepository.DeleteAsync(question);
            await _questionRepository.RemoveNoRelationQuestionDetail();

        }
    }
}
