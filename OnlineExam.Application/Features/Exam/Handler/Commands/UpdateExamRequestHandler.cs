using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Exam.Validation;
using OnlineExam.Application.Features.Exam.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Helper;
using OnlineExam.Application.Contracts.Identity;
using FluentValidation;
using OnlineExam.Application.DTOs.Exam;

namespace OnlineExam.Application.Features.Exam.Handler.Commands
{
    public class UpdateExamRequestHandler : IRequestHandler<UpdateExamRequest>
    {
        private readonly IExamRepository _examRepository;
        private readonly IAuthServices _authServices;
        private readonly IValidator<UpdateExamDTO> _validator;
        public UpdateExamRequestHandler(IExamRepository examRepository, IAuthServices authServices, IValidator<UpdateExamDTO> validator)
        {
            _examRepository = examRepository;
            _authServices = authServices;
            _validator = validator;
        }

        public async Task Handle(UpdateExamRequest request, CancellationToken cancellationToken)
        {
            bool examExist = await _examRepository.ExistAsync(request.Id);
            if(examExist==false)
            {
                throw new NotFoundException("آزمون یافت نشد.");
            }
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            bool isTeacher = await _examRepository.IsUserTeacherAsync(currentUser, request.Id);
            bool isAdmin = await _authServices.IsUserAdminAsync(currentUser);
            if (!isTeacher && !isAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی به این عملیات را ندارید.");
            }

            var validationResult = await _validator.ValidateAsync(request.UpdateExamDTO);
            if(validationResult.IsValid==false)
            {
                throw new Application.Exceptions.ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            await _examRepository.UpdateAsync(request.Id, request.UpdateExamDTO);
        }
    }
}
