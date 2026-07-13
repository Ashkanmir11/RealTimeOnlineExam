using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.LogType;
using OnlineExam.Application.Features.LogType.Reqeust.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.LogType.Handler.Queries
{
    public class GetLogTypeByIdRequestHandler : IRequestHandler<GetLogTypeByIdRequest, GetLogTypeDTO>
    {
        private ILogTypeRepository _logTypeRepository;
        public GetLogTypeByIdRequestHandler(ILogTypeRepository logTypeRepository)
        {
            _logTypeRepository = logTypeRepository;
        }
        public async Task<GetLogTypeDTO> Handle(GetLogTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _logTypeRepository.GetAsync<GetLogTypeDTO>(request.Id);
            return result;
        }
    }
}
