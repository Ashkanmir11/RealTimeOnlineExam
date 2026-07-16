using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers.Validation;
using OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Handler.Commands
{
    public class CreateMultipleChoiceAnswerRequestHandler : IRequestHandler<CreateMultipleChoiceAnswerRequest>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMultipleChoiceAnswersRepository _MultipleChoiceAnswersRepository;
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;
        public CreateMultipleChoiceAnswerRequestHandler(IAccountRepository accountRepository, 
            IMultipleChoiceAnswersRepository MultipleChoiceAnswersRepository,
            IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository)
        {
            _accountRepository = accountRepository;
            _MultipleChoiceAnswersRepository = MultipleChoiceAnswersRepository;
            _multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
        }

        public async Task Handle(CreateMultipleChoiceAnswerRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateMultipleChoiceAnswerValidation(_accountRepository,_multipleChoiceQuestionRepository);
            var validationResult = await validator.ValidateAsync(request.CreateMultipleChoiceQuestionAnswerDTO);
            if (validationResult.IsValid == false)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationException(errors);
            }
            await _MultipleChoiceAnswersRepository.AddAsync<CreateMultipleChoiceAnswerDTO>(request.CreateMultipleChoiceQuestionAnswerDTO);
        }
    }
}
