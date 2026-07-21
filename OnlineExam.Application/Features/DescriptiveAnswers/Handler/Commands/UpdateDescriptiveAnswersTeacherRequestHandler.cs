using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace OnlineExam.Application.Features.DescriptiveAnswers.Handler.Commands
{
    public class UpdateDescriptiveAnswersTeacherRequestHandler : IRequestHandler<UpdateDescriptiveAnswersTeacherRequest>
    {
        private readonly IValidator<UpdateDescriptiveAnswersTeacherDTO> _validator;
        private readonly IAuthServices _authServices;
        private readonly IClassRoomRepository _classRepository;
        private readonly IDescriptiveAnswersRepository _descriptiveAnswersRepository;

        public UpdateDescriptiveAnswersTeacherRequestHandler(IValidator<UpdateDescriptiveAnswersTeacherDTO> validator, IAuthServices authServices
            , IClassRoomRepository classRepository , IDescriptiveAnswersRepository descriptiveAnswersRepository)
        {
            _validator = validator;
            _authServices = authServices;
            _classRepository = classRepository;
            _descriptiveAnswersRepository = descriptiveAnswersRepository;
        }

        public async Task Handle(UpdateDescriptiveAnswersTeacherRequest request, CancellationToken cancellationToken)
        {
            //Check User is teacher
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var isTeacher = await _classRepository.IsUserTeacherByExamIdAsync(request.ExamId, currentUser);
            if (isTeacher == false)
            {
                throw new UnauthorizedAccessException("شما دسترسی به این سوالات ندارید.");
            }
            var validationResult = await _validator.ValidateAsync(request.updateDescriptiveAnswersTeacherDTO);
            if(validationResult.IsValid==false)
            {
                var errprs=validationResult.Errors.Select(e=>e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errprs);
            }
            await _descriptiveAnswersRepository.UpdateAsync(request.updateDescriptiveAnswersTeacherDTO.Id, request.updateDescriptiveAnswersTeacherDTO);
        }
    }
}
