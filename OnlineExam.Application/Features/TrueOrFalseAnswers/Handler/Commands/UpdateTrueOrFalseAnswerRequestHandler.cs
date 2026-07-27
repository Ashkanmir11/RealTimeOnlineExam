using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion.Validation;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers.Validation;
using OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using FluentValidation;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Handler.Commands
{
    public class UpdateTrueOrFalseAnswerRequestHandler : IRequestHandler<UpdateTrueOrFalseAnswerRequest>
    {
        private readonly ITrueOrFalseAnswersRepository _TrueOrFalseAnswersRepository;
        private readonly IExamAttamptRepository _examAttamptRepository;
        private readonly IAuthServices _authServices;
        private readonly IValidator<UpdateTrueOrFalseAnswerDTO> _validator;

        public UpdateTrueOrFalseAnswerRequestHandler(ITrueOrFalseAnswersRepository TrueOrFalseAnswersRepository, IExamAttamptRepository examAttamptRepository
            , IAuthServices authServices, IValidator<UpdateTrueOrFalseAnswerDTO> validator)
        {
            _TrueOrFalseAnswersRepository = TrueOrFalseAnswersRepository;
            _authServices=authServices;
            _examAttamptRepository = examAttamptRepository;
            _validator = validator;
        }
        public async Task Handle(UpdateTrueOrFalseAnswerRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var isAdmin = await _authServices.IsUserAdminAsync(currentUser);
            var questionAnswer = await _TrueOrFalseAnswersRepository.GetAsync(request.Id);
            if(questionAnswer==null)
            {
                throw new NotFoundException("پاسخ یافت نشد.");
            }
            if (questionAnswer.StudentId != currentUser && !isAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی این عملیات را ندارید.");
            }

            var validationResult = await _validator.ValidateAsync(request.UpdateTrueOrFalseQuestionAnswerDTO);
            if (validationResult.IsValid == false)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);
            }
            var examEnded = await _examAttamptRepository.ExamEndedAsync(request.UpdateTrueOrFalseQuestionAnswerDTO.ExamId, currentUser);
            if (examEnded)
            {
                throw new AccessForbiddenException("آزمون به پایان رسیده.");
            }
            await _TrueOrFalseAnswersRepository.UpdateAsync(request.Id, request.UpdateTrueOrFalseQuestionAnswerDTO);
        }
    }
}
