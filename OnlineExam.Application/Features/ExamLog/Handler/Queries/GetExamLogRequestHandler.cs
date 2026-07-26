using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ExamLog;
using OnlineExam.Application.Features.ExamLog.Request.Queries;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ExamLog.Handler.Queries
{
    public class GetExamLogRequestHandler : IRequestHandler<GetExamLogRequest, PaginateResponse<GetExamLogDTO>>
    {
        private readonly IExamLogRepository _examLogRepository;
        private readonly IAccountRepository _accountRepository;
        public GetExamLogRequestHandler(IExamLogRepository examLogRepository, IAccountRepository accountRepository)
        {
            _examLogRepository = examLogRepository;
            _accountRepository = accountRepository;
        }
        public async Task<PaginateResponse<GetExamLogDTO>> Handle(GetExamLogRequest request, CancellationToken cancellationToken)
        {
            var logs = await _examLogRepository.GetAllAsync<GetExamLogDTO>(request.PaginateRequestDTO);
            if (logs.Data.Count == 0)
            {
                return null;
            }
            foreach(var log in logs.Data)
            {
                log.Student = await _accountRepository.GetUserByIdAsync(log.StudentId);
            }
            
            return logs;
        }
    }
}
