using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Objection;
using OnlineExam.Application.Features.Objection.Request.Queries;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Objection.Handler.Queries
{
    public class GetObjectionRequestHandler : IRequestHandler<GetObjectionRequest, PaginateResponse<GetObjectionDTO>>
    {
        private readonly IObjectionRepository _objectionRepository;
        public GetObjectionRequestHandler(IObjectionRepository objectionRepository)
        {
            _objectionRepository = objectionRepository;
        }
        public async Task<PaginateResponse<GetObjectionDTO>> Handle(GetObjectionRequest request, CancellationToken cancellationToken)
        {
            return await _objectionRepository.GetAllAsync<GetObjectionDTO>(request.PaginateRequest);
        }
    }
}
