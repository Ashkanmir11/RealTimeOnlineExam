using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Handler.Commands
{
    public class UpdateMultipleChoiceAnswerTeacherRequestHandler : IRequestHandler<UpdateMultipleChoiceAnswerTeacherRequest>
    {
        private readonly IValidator<UpdateMultipleChoiceAnswerTeacherDTO> _validator;
        private readonly IAuthServices _authServices;
        private readonly IClassRoomRepository _classRepository;
        private readonly IMultipleChoiceAnswersRepository _multipleChoiceAnswerRepository;
        public UpdateMultipleChoiceAnswerTeacherRequestHandler(IValidator<UpdateMultipleChoiceAnswerTeacherDTO> validator, IAuthServices authServices, IClassRoomRepository classRepository, IMultipleChoiceAnswersRepository multipleChoiceAnswerRepository)
        {
            _validator = validator;
            _authServices = authServices;
            _classRepository = classRepository;
            _multipleChoiceAnswerRepository = multipleChoiceAnswerRepository;
        }

        public async Task Handle(UpdateMultipleChoiceAnswerTeacherRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var isTeacher = await _classRepository.IsUserTeacherByExamIdAsync(request.ExamId, currentUser);
            if (isTeacher == false)
            {
                throw new AccessForbiddenException("شما دسترسی به این سوالات ندارید.");
            }
            var validationResult = await _validator.ValidateAsync(request.UpdateMultipleChoiceAnswerTeacherDTO);
            if (validationResult.IsValid == false)
            {
                var errprs = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errprs);
            }
            await _multipleChoiceAnswerRepository.UpdateAsync(request.UpdateMultipleChoiceAnswerTeacherDTO.Id, request.UpdateMultipleChoiceAnswerTeacherDTO);
        }
    }
}
