using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.Objection.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Application.Features.Objection.Handler.Commands
{
    public class DeleteOnjectionRequestHandler : IRequestHandler<DeleteOnjectionRequest>
    {
        private readonly IObjectionRepository _objectionRepository;
        public DeleteOnjectionRequestHandler(IObjectionRepository objectionRepository)
        {
            _objectionRepository = objectionRepository;
        }

        public async Task Handle(DeleteOnjectionRequest request, CancellationToken cancellationToken)
        {
            var objection = await _objectionRepository.GetAsync(request.Id);
            if (objection == null)
            {
                throw new BadRequestException($"آیدی {request.Id} یافت نشد.");
            }
            await _objectionRepository.DeleteAsync(objection);
        }
    }
}
