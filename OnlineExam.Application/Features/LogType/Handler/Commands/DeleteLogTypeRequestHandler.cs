using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.LogType.Reqeust.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.LogType.Handler.Commands
{
    public class DeleteLogTypeRequestHandler : IRequestHandler<DeleteLogTypeRequest>
    {
        private readonly ILogTypeRepository _logTypeRepository;
        public DeleteLogTypeRequestHandler(ILogTypeRepository logTypeRepository)
        {
            _logTypeRepository = logTypeRepository;
        }
        public async Task Handle(DeleteLogTypeRequest request, CancellationToken cancellationToken)
        {
            var logType = await _logTypeRepository.GetAsync(request.Id);
            if(logType == null)
            {
                throw new NotFoundException($"نوع لاگ با آیدی {request.Id} یافت نشد.");
            }
            await _logTypeRepository.DeleteAsync(logType);
        }
    }
}
