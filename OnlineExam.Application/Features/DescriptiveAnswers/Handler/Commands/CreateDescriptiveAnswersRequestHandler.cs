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

namespace OnlineExam.Application.Features.DescriptiveAnswers.Handler.Commands
{
    public class CreateDescriptiveAnswersRequestHandler : IRequestHandler<CreateDescriptiveAnswersRequest>
    {
        private readonly IDescriptiveAnswersRepository _DescriptiveAnswersRepository;
        private readonly IDescriptiveQuestionRepository _descriptiveQuestionRepository;
        private readonly IAccountRepository _accountRepository;
        public CreateDescriptiveAnswersRequestHandler(IDescriptiveAnswersRepository DescriptiveAnswersRepository,
            IDescriptiveQuestionRepository descriptiveQuestionRepository,
            IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _DescriptiveAnswersRepository = DescriptiveAnswersRepository;
            _descriptiveQuestionRepository = descriptiveQuestionRepository;
        }

        public async Task Handle(CreateDescriptiveAnswersRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateDescriptiveAnswersValidation(_accountRepository, _descriptiveQuestionRepository);
            var validationResult = await validator.ValidateAsync(request.CreateDescriptiveAnswersDTO);
            if (validationResult.IsValid == false)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationException(errors);
            }
            await _DescriptiveAnswersRepository.AddAsync<CreateDescriptiveAnswersDTO>(request.CreateDescriptiveAnswersDTO);
        }
    }
}
