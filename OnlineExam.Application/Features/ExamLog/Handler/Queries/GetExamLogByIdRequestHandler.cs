using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ExamLog;
using OnlineExam.Application.Features.ExamLog.Request.Queries;

namespace OnlineExam.Application.Features.ExamLog.Handler.Queries
{
    public class GetExamLogByIdRequestHandler : IRequestHandler<GetExamLogByIdRequest, GetExamLogDTO>
    {
        private readonly IExamLogRepository _examLogRepository;
        private readonly IAccountRepository _accountRepository;
        public GetExamLogByIdRequestHandler(IExamLogRepository examLogRepository, IAccountRepository accountRepository)
        {
            _examLogRepository = examLogRepository;
            _accountRepository = accountRepository;
        }

        public async Task<GetExamLogDTO> Handle(GetExamLogByIdRequest request, CancellationToken cancellationToken)
        {
            var log = await _examLogRepository.GetAsync<GetExamLogDTO>(request.Id);
            if (log == null)
            {
                return null;
            }
            log.Student = await _accountRepository.GetUserByIdAsync(log.StudentId);
            return log;
        }
    }
}
