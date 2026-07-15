using MediatR;
using OnlineExam.Application.DTOs.DescriptiveQuestionAnswers.Validation;
using OnlineExam.Application.Features.DescriptiveQuestionAnswers.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.DescriptiveQuestionAnswers;

namespace OnlineExam.Application.Features.DescriptiveQuestionAnswers.Handler.Commands
{
    public class CreateDescriptiveQuestionAnswersRequestHandler : IRequestHandler<CreateDescriptiveQuestionAnswersRequest>
    {
        private readonly IDescriptiveQuestionAnswersRepository _descriptiveQuestionAnswersRepository;
        private readonly IDescriptiveQuestionRepository _descriptiveQuestionRepository;
        private readonly IAccountRepository _accountRepository;
        public CreateDescriptiveQuestionAnswersRequestHandler(IDescriptiveQuestionAnswersRepository descriptiveQuestionAnswersRepository,
            IDescriptiveQuestionRepository descriptiveQuestionRepository,
            IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _descriptiveQuestionAnswersRepository = descriptiveQuestionAnswersRepository;
            _descriptiveQuestionRepository = descriptiveQuestionRepository;
        }

        public async Task Handle(CreateDescriptiveQuestionAnswersRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateDescriptiveQuestionAnswersValidation(_accountRepository, _descriptiveQuestionRepository);
            var validationResult = await validator.ValidateAsync(request.CreateDescriptiveQuestionAnswersDTO);
            if (validationResult.IsValid == false)
            {
                string massage = ListToStringHelper.CreateString(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                throw new ValidationException(massage);
            }
            await _descriptiveQuestionAnswersRepository.AddAsync<CreateDescriptiveQuestionAnswersDTO>(request.CreateDescriptiveQuestionAnswersDTO);
        }
    }
}
