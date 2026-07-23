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

namespace OnlineExam.Application.Features.Exam.Handler.Commands
{
    public class UpdateExamRequestHandler : IRequestHandler<UpdateExamRequest>
    {
        private readonly IExamRepository _examRepository;
        private readonly IAuthServices _authServices;
        public UpdateExamRequestHandler(IExamRepository examRepository, IAuthServices authServices)
        {
            _examRepository = examRepository;
            _authServices = authServices;
        }

        public async Task Handle(UpdateExamRequest request, CancellationToken cancellationToken)
        {

            var currentUser = await _authServices.GetCurrentUserIdAsync();
            bool isTeacher = await _examRepository.IsUserTeacherAsync(currentUser, request.UpdateExamDTO.Id);
            bool isAdmin = await _authServices.IsUserAdminAsync(currentUser);
            if (!isTeacher && !isAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی به این عملیات را ندارید.");
            }

            var validator = new UpdateExamValidation(_examRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateExamDTO);
            if(validationResult.IsValid==false)
            {
                throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            await _examRepository.UpdateAsync(request.UpdateExamDTO.Id, request.UpdateExamDTO);
        }
    }
}
