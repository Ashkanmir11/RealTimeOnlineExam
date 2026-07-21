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
using FluentValidation;
namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Handler.Commands
{
    public class CreateTrueOrFalseAnswerRequestHandler : IRequestHandler<CreateTrueOrFalseAnswerRequest>
    {
        private readonly ITrueOrFalseAnswersRepository _TrueOrFalseAnswersRepository;
        private readonly IAuthServices _authServices;
        private readonly IValidator<CreateTrueOrFalseAnswerDTO> _validator;
        private readonly IExamAttamptRepository _examAttamptRepository;
        public CreateTrueOrFalseAnswerRequestHandler(ITrueOrFalseAnswersRepository TrueOrFalseAnswersRepository,IAuthServices authServices, IValidator<CreateTrueOrFalseAnswerDTO> validator, IExamAttamptRepository examAttamptRepository)
        {
            _TrueOrFalseAnswersRepository = TrueOrFalseAnswersRepository;
            _authServices = authServices;
            _validator = validator;
            _examAttamptRepository = examAttamptRepository;
        }

        public async Task Handle(CreateTrueOrFalseAnswerRequest request, CancellationToken cancellationToken)
        {
            request.CreateTrueOrFalseQuestionAnswerDTO.StudentId = await _authServices.GetCurrentUserIdAsync();
            var validationResult = await _validator.ValidateAsync(request.CreateTrueOrFalseQuestionAnswerDTO);
            if (validationResult.IsValid == false)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);
            }

            var ExamEnded = await _examAttamptRepository.ExamEndedAsync(request.CreateTrueOrFalseQuestionAnswerDTO.ExamId, request.CreateTrueOrFalseQuestionAnswerDTO.StudentId);
            if (ExamEnded)
            {
                throw new UnauthorizedAccessException("آزمون به پایان رسیده است.");
            }
            await _TrueOrFalseAnswersRepository.AddAsync<CreateTrueOrFalseAnswerDTO>(request.CreateTrueOrFalseQuestionAnswerDTO);
        }
    }
}
