using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers.Validation;
using OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Helper;
using OnlineExam.Application.Contracts.Identity;
using FluentValidation;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Handler.Commands
{
    public class UpdateMultipleChoiceAnswerRequestHandler : IRequestHandler<UpdateMultipleChoiceAnswerRequest>
    {
        private readonly IMultipleChoiceAnswersRepository _MultipleChoiceAnswersRepository;
        private readonly IExamAttamptRepository _examAttamptRepository;
        private readonly IAuthServices _authServices;
        private readonly IValidator<UpdateMultipleChoiceAnswerDTO> _validator;
        public UpdateMultipleChoiceAnswerRequestHandler(IMultipleChoiceAnswersRepository MultipleChoiceAnswersRepository, IExamAttamptRepository examAttamptRepository
            , IAuthServices authServices, IValidator<UpdateMultipleChoiceAnswerDTO> validator)
        {
            _MultipleChoiceAnswersRepository = MultipleChoiceAnswersRepository;
            _examAttamptRepository= examAttamptRepository;
            _authServices= authServices;
            _validator = validator;
        }
        public async Task Handle(UpdateMultipleChoiceAnswerRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var isAdmin = await _authServices.IsUserAdminAsync(currentUser);
            var questionAnswer = await _MultipleChoiceAnswersRepository.GetAsync(request.Id);

            if (questionAnswer==null || questionAnswer.StudentId != currentUser && !isAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی این عملیات را ندارید.");
            }

            var validationResult = await _validator.ValidateAsync(request.UpdateMultipleChoiceQuestionAnswerDTO);
            if(validationResult.IsValid==false)
            {
                var errors = validationResult.Errors.Select(e=>e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);
            }
            var examEnded = await _examAttamptRepository.ExamEndedAsync(request.UpdateMultipleChoiceQuestionAnswerDTO.ExamId, currentUser);
            if (examEnded)
            {
                throw new AccessForbiddenException("آزمون به پایان رسیده.");
            }

            await _MultipleChoiceAnswersRepository.UpdateAsync(request.Id, request.UpdateMultipleChoiceQuestionAnswerDTO);
        }
    }
}
