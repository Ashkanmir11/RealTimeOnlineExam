using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Objection;
using OnlineExam.Application.Features.Objection.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Objection.Handler.Queries
{
    public class GetObjectionByIdRequestHandler : IRequestHandler<GetObjectionByIdRequest, GetObjectionDTO>
    {
        private readonly IObjectionRepository _objectionRepository;
        public GetObjectionByIdRequestHandler(IObjectionRepository objectionRepository)
        {
            _objectionRepository = objectionRepository;
        }

        public async Task<GetObjectionDTO> Handle(GetObjectionByIdRequest request, CancellationToken cancellationToken)
        {
           return await _objectionRepository.GetAsync<GetObjectionDTO>(request.Id);
            
        }
    }
}
