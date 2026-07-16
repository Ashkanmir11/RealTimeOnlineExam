using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.TrueOrFalseQuestionAnswers.Validation;
using OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.DTOs.TrueOrFalseQuestionAnswers;
namespace OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Handler.Commands
{
    public class CreateTrueOrFalseQuestionAnswerRequestHandler : IRequestHandler<CreateTrueOrFalseQuestionAnswerRequest>
    {
        private readonly ITrueOrFalseQuestionAnswersRepository _trueOrFalseQuestionAnswersRepository;
        private readonly ITrueOrFalseQuestionRepository _trueOrFalseQuestionRepository;
        private readonly IAccountRepository _accountRepository;
        public CreateTrueOrFalseQuestionAnswerRequestHandler(ITrueOrFalseQuestionAnswersRepository trueOrFalseQuestionAnswersRepository, ITrueOrFalseQuestionRepository trueOrFalseQuestionRepository, IAccountRepository accountRepository)
        {
            _trueOrFalseQuestionAnswersRepository = trueOrFalseQuestionAnswersRepository;
            _trueOrFalseQuestionRepository = trueOrFalseQuestionRepository;
            _accountRepository = accountRepository;
        }

        public async Task Handle(CreateTrueOrFalseQuestionAnswerRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateTrueOrFalseQuestionAnswerValidation(_trueOrFalseQuestionRepository,_accountRepository);
            var validationResult = await validator.ValidateAsync(request.CreateTrueOrFalseQuestionAnswerDTO);
            if(validationResult.IsValid==false)
            {
                var massage = ListToStringHelper.CreateString(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                throw new ValidationException(massage);
            }
            await _trueOrFalseQuestionAnswersRepository.AddAsync<CreateTrueOrFalseQuestionAnswerDTO>(request.CreateTrueOrFalseQuestionAnswerDTO);
        }
    }
}
