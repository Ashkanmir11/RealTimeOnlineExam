using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.Exam.Request.Commands;

namespace OnlineExam.Application.Features.Exam.Handler.Commands
{
    public class DeleteExamRequestHandler : IRequestHandler<DeleteExamRequest>
    {
        private readonly IExamRepository _examRepository;
        private readonly IAuthServices _authServices;
        private readonly IQuestionRepository _questionRepository;
        public DeleteExamRequestHandler(IExamRepository examRepository, IAuthServices authServices, IQuestionRepository questionRepository)
        {
            _examRepository = examRepository;
            _authServices = authServices;
            _questionRepository = questionRepository;
        }
        public async Task Handle(DeleteExamRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            bool isTeacher = await _examRepository.IsUserTeacherAsync(currentUser, request.Id);
            bool isAdmin = await _authServices.IsUserAdminAsync(currentUser);
            if (!isTeacher && !isAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی به این عملیات را ندارید.");
            }

            var exam = await _examRepository.GetAsync(request.Id);
            if (exam == null)
            {
                throw new NotFoundException($"آزمون با آیدی {exam.Id} یافت نشد.");
            }
            await _examRepository.DeleteAsync(exam);
            await _questionRepository.RemoveNoRelationQuestionDetail();
        }
    }
}
