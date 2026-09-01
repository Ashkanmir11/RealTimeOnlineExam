using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.LogType;
using OnlineExam.Application.Features.LogType.Reqeust.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.LogType.Handler.Queries
{
    public class GetLogTypeRequestHandler : IRequestHandler<GetLogTypeRequest, PaginateResponse<GetLogTypeDTO>>
    {
        private ILogTypeRepository _logTypeRepository;
        public GetLogTypeRequestHandler(ILogTypeRepository logTypeRepository)
        {
            _logTypeRepository = logTypeRepository;
        }
        public async Task<PaginateResponse<GetLogTypeDTO>> Handle(GetLogTypeRequest request, CancellationToken cancellationToken)
        {
            var result = await _logTypeRepository.GetAllAsync<GetLogTypeDTO>(request.PaginateRequestDTO);
            return result;
        }
    }
}
