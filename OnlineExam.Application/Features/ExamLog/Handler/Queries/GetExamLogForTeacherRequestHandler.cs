using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ExamLog;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.ExamLog.Request.Queries;
namespace OnlineExam.Application.Features.ExamLog.Handler.Queries
{
    public class GetExamLogForTeacherRequestHandler : IRequestHandler<GetExamLogForTeacherRequest, List<GetExamLogDTO>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IExamLogRepository _examLogRepository;
        private readonly IExamRepository _examRepository;
        private readonly IAuthServices _authServices;
        public GetExamLogForTeacherRequestHandler(IAccountRepository accountRepository, IExamLogRepository examLogRepository, IExamRepository examRepository, IAuthServices authServices)
        {
            _accountRepository = accountRepository;
            _examLogRepository = examLogRepository;
            _examRepository = examRepository;
            _authServices = authServices;
        }

        public async Task<List<GetExamLogDTO>> Handle(GetExamLogForTeacherRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();

            bool isTeacher = await _examRepository.IsUserTeacherAsync(currentUser, request.ExamId);
            if (!isTeacher)
            {
                throw new AccessForbiddenException("شما دسترسی به این کلاس ندارید.");
            }
            var studentLogs = await _examLogRepository.GetForTeacher(request.StudentId, request.ExamId);
            if (studentLogs.Count == 0)
            {
                return null;
            }
            foreach (var studentLog in studentLogs)
            {
                studentLog.Student = await _accountRepository.GetUserByIdAsync(studentLog.StudentId);
            }

            return studentLogs;
        }
    }
}
