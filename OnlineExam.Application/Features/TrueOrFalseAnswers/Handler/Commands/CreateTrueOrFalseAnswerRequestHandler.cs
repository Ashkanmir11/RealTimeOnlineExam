using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers.Validation;
using OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Handler.Commands
{
    public class CreateTrueOrFalseAnswerRequestHandler : IRequestHandler<CreateTrueOrFalseAnswerRequest>
    {
        private readonly ITrueOrFalseAnswersRepository _TrueOrFalseAnswersRepository;
        private readonly ITrueOrFalseQuestionRepository _trueOrFalseQuestionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthServices _authServices;
        public CreateTrueOrFalseAnswerRequestHandler(ITrueOrFalseAnswersRepository TrueOrFalseAnswersRepository
            , ITrueOrFalseQuestionRepository trueOrFalseQuestionRepository
            , IAccountRepository accountRepository,IAuthServices authServices)
        {
            _TrueOrFalseAnswersRepository = TrueOrFalseAnswersRepository;
            _trueOrFalseQuestionRepository = trueOrFalseQuestionRepository;
            _accountRepository = accountRepository;
            _authServices = authServices;
        }

        public async Task Handle(CreateTrueOrFalseAnswerRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateTrueOrFalseAnswerValidation(_trueOrFalseQuestionRepository, _accountRepository);
            var validationResult = await validator.ValidateAsync(request.CreateTrueOrFalseQuestionAnswerDTO);
            if (validationResult.IsValid == false)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationException(errors);
            }
            request.CreateTrueOrFalseQuestionAnswerDTO.StudentId = await _authServices.GetCurrentUserId();
            await _TrueOrFalseAnswersRepository.AddAsync<CreateTrueOrFalseAnswerDTO>(request.CreateTrueOrFalseQuestionAnswerDTO);
        }
    }
}
