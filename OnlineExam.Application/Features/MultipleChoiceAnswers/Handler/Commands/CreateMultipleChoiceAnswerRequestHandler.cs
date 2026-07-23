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
using FluentValidation;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Handler.Commands
{
    public class CreateMultipleChoiceAnswerRequestHandler : IRequestHandler<CreateMultipleChoiceAnswerRequest>
    {
        private readonly IMultipleChoiceAnswersRepository _MultipleChoiceAnswersRepository;
        private readonly IAuthServices _authServices;
        private readonly IValidator<CreateMultipleChoiceAnswerDTO> _validator;
        private readonly IExamAttamptRepository _examAttamptRepository;
        public CreateMultipleChoiceAnswerRequestHandler(IMultipleChoiceAnswersRepository MultipleChoiceAnswersRepository,
            IAuthServices authServices, IValidator<CreateMultipleChoiceAnswerDTO> validator, IExamAttamptRepository examAttamptRepository)
        {
            _MultipleChoiceAnswersRepository = MultipleChoiceAnswersRepository;
            _authServices = authServices;
            _validator = validator;
            _examAttamptRepository = examAttamptRepository;
        }

        public async Task Handle(CreateMultipleChoiceAnswerRequest request, CancellationToken cancellationToken)
        {
            request.CreateMultipleChoiceQuestionAnswerDTO.StudentId = await _authServices.GetCurrentUserIdAsync();
            var validationResult = await _validator.ValidateAsync(request.CreateMultipleChoiceQuestionAnswerDTO);
            if (validationResult.IsValid == false)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);
            }


            var ExamEnded = await _examAttamptRepository.ExamEndedAsync(request.CreateMultipleChoiceQuestionAnswerDTO.ExamId, request.CreateMultipleChoiceQuestionAnswerDTO.StudentId);
            if (ExamEnded)
            {
                throw new AccessForbiddenException("آزمون به پایان رسیده است.");
            }
            await _MultipleChoiceAnswersRepository.AddAsync<CreateMultipleChoiceAnswerDTO>(request.CreateMultipleChoiceQuestionAnswerDTO);
        }
    }
}
