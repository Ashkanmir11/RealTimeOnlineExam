using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.DTOs.DescriptiveAnswers.Validation;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using FluentValidation;
namespace OnlineExam.Application.Features.DescriptiveAnswers.Handler.Commands
{
    public class UpdateDescriptiveAnswersRequestHandler : IRequestHandler<UpdateDescriptiveAnswersRequest>
    {
        private readonly IDescriptiveAnswersRepository _DescriptiveAnswersRepository;
        private readonly IExamAttamptRepository _examAttamptRepository;
        private readonly IAuthServices _authServices;
        private readonly IValidator<UpdateDescriptiveAnswersDTO> _validator;
        public UpdateDescriptiveAnswersRequestHandler(IAuthServices authServices, IDescriptiveAnswersRepository DescriptiveAnswersRepository
            , IExamAttamptRepository examAttamptRepository, IValidator<UpdateDescriptiveAnswersDTO> validator)
        {
            _DescriptiveAnswersRepository = DescriptiveAnswersRepository;
            _examAttamptRepository = examAttamptRepository;
            _authServices = authServices;
            _validator = validator;
        }

        public async Task Handle(UpdateDescriptiveAnswersRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var isAdmin = await _authServices.IsUserAdminAsync(currentUser);
            var questionAnswer = await _DescriptiveAnswersRepository.GetAsync(request.UpdateDescriptiveAnswersDTO.Id);

            if (questionAnswer.StudentId != currentUser && !isAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی این عملیات را ندارید.");
            }

            var validationResult = await _validator.ValidateAsync(request.UpdateDescriptiveAnswersDTO);
            if (validationResult.IsValid == false)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);
            }
            var examEnded = await _examAttamptRepository.ExamEndedAsync(request.UpdateDescriptiveAnswersDTO.ExamId,currentUser);
            if(examEnded)
            {
                throw new AccessForbiddenException("آزمون به پایان رسیده.");
            }
            await _DescriptiveAnswersRepository.UpdateAsync(request.UpdateDescriptiveAnswersDTO.Id, request.UpdateDescriptiveAnswersDTO);
        }
    }
}
