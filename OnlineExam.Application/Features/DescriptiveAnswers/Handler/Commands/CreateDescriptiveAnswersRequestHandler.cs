using MediatR;
using OnlineExam.Application.DTOs.DescriptiveAnswers.Validation;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using FluentValidation;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Handler.Commands
{
    public class CreateDescriptiveAnswersRequestHandler : IRequestHandler<CreateDescriptiveAnswersRequest>
    {
        private readonly IDescriptiveAnswersRepository _DescriptiveAnswersRepository;
        private readonly IDescriptiveQuestionRepository _descriptiveQuestionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthServices _authServices;
        private readonly IValidator<CreateDescriptiveAnswersDTO> _validator;

        public CreateDescriptiveAnswersRequestHandler(IDescriptiveAnswersRepository DescriptiveAnswersRepository,
            IDescriptiveQuestionRepository descriptiveQuestionRepository,
            IAccountRepository accountRepository,
            IAuthServices authServices, IValidator<CreateDescriptiveAnswersDTO> validator)
        {
            _accountRepository = accountRepository;
            _DescriptiveAnswersRepository = DescriptiveAnswersRepository;
            _descriptiveQuestionRepository = descriptiveQuestionRepository;
            _authServices = authServices;
            _validator = validator;
        }

        public async Task Handle(CreateDescriptiveAnswersRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.CreateDescriptiveAnswersDTO);
            if (validationResult.IsValid == false)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);
            }
            request.CreateDescriptiveAnswersDTO.StudentId = await _authServices.GetCurrentUserId();
            await _DescriptiveAnswersRepository.AddAsync<CreateDescriptiveAnswersDTO>(request.CreateDescriptiveAnswersDTO);
        }
    }
}
