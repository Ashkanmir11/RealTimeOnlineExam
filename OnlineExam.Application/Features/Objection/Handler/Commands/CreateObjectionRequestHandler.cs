using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Objection.Validation;
using OnlineExam.Application.Features.Objection.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Helper;
using OnlineExam.Application.DTOs.Objection;
using AutoMapper;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.Features.Objection.Handler.Commands
{
    public class CreateObjectionRequestHandler : IRequestHandler<CreateObjectionReqeust, GetObjectionDTO>
    {
        private readonly IObjectionRepository _objectionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;
        public CreateObjectionRequestHandler(IObjectionRepository objectionRepository, IAccountRepository accountRepository, IExamRepository examRepository, IMapper mapper)
        {
            _objectionRepository = objectionRepository;
            _accountRepository = accountRepository;
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<GetObjectionDTO> Handle(CreateObjectionReqeust request, CancellationToken cancellationToken)
        {
            var validator = new CreateObjectionValidation(_accountRepository, _examRepository);
            var validatorResult = await validator.ValidateAsync(request.CreateObjectionDTO);
            if (validatorResult.IsValid == false)
            {
                throw new ValidationException(validatorResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            var response = await _objectionRepository.AddAsync<CreateObjectionDTO>(request.CreateObjectionDTO);
            return _mapper.Map<GetObjectionDTO>(response);

        }
    }
}
