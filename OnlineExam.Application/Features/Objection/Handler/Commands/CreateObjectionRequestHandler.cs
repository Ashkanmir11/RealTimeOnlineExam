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
using FluentValidation;

namespace OnlineExam.Application.Features.Objection.Handler.Commands
{
    public class CreateObjectionRequestHandler : IRequestHandler<CreateObjectionReqeust>
    {
        private readonly IObjectionRepository _objectionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IExamRepository _examRepository;
        private readonly IAuthServices _authServices;
        private readonly IValidator<CreateObjectionDTO> _validator;
        public CreateObjectionRequestHandler(IObjectionRepository objectionRepository, IAccountRepository accountRepository
            , IExamRepository examRepository, IAuthServices authServices, IValidator<CreateObjectionDTO> validator)
        {
            _objectionRepository = objectionRepository;
            _accountRepository = accountRepository;
            _examRepository = examRepository;
            _authServices= authServices;
            _validator = validator;
        }

        public async Task Handle(CreateObjectionReqeust request, CancellationToken cancellationToken)
        {
            var validatorResult = await _validator.ValidateAsync(request.CreateObjectionDTO);
            if (validatorResult.IsValid == false)
            {
                throw new Application.Exceptions.ValidationException(validatorResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            request.CreateObjectionDTO.StudentId = await _authServices.GetCurrentUserId();
            await _objectionRepository.AddAsync<CreateObjectionDTO>(request.CreateObjectionDTO);

        }
    }
}
