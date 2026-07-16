using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers.Validation;
using OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers;
namespace OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Handler.Commands
{
    public class CreateMultipleChoiceQuestionAnswerRequestHandler : IRequestHandler<CreateMultipleChoiceQuestionAnswerRequest>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMultipleChoiceQuestionAnswersRepository _multipleChoiceQuestionAnswersRepository;
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;
        public CreateMultipleChoiceQuestionAnswerRequestHandler(IAccountRepository accountRepository, 
            IMultipleChoiceQuestionAnswersRepository multipleChoiceQuestionAnswersRepository,
            IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository)
        {
            _accountRepository = accountRepository;
            _multipleChoiceQuestionAnswersRepository = multipleChoiceQuestionAnswersRepository;
            _multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
        }

        public async Task Handle(CreateMultipleChoiceQuestionAnswerRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateMultipleChoiceQuestionAnswerValidation(_accountRepository,_multipleChoiceQuestionRepository);
            var validationResult = await validator.ValidateAsync(request.CreateMultipleChoiceQuestionAnswerDTO);
            if (validationResult.IsValid == false)
            {
                string massage = ListToStringHelper.CreateString(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                throw new ValidationException(massage);
            }
            await _multipleChoiceQuestionAnswersRepository.AddAsync<CreateMultipleChoiceQuestionAnswerDTO>(request.CreateMultipleChoiceQuestionAnswerDTO);
        }
    }
}
