using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Handler.Commands
{
    public class UpdateTrueOrFalseAnswerTeacherRequestHandler : IRequestHandler<UpdateTrueOrFalseAnswerTeacherRequest>
    {
        private readonly IValidator<UpdateTrueOrFalseAnswerTeacherDTO> _validator;
        private readonly IAuthServices _authServices;
        private readonly IClassRoomRepository _classRepository;
        private readonly ITrueOrFalseAnswersRepository _trueOrFalseAnswersRepository;

        public UpdateTrueOrFalseAnswerTeacherRequestHandler(IValidator<UpdateTrueOrFalseAnswerTeacherDTO> validator, IAuthServices authServices
            , IClassRoomRepository classRepository, ITrueOrFalseAnswersRepository trueOrFalseAnswersRepository)
        {
            _validator = validator;
            _authServices = authServices;
            _classRepository = classRepository;
            _trueOrFalseAnswersRepository = trueOrFalseAnswersRepository;
        }
        public async Task Handle(UpdateTrueOrFalseAnswerTeacherRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var isTeacher = await _classRepository.IsUserTeacherByExamIdAsync(request.ExamId, currentUser);
            if (isTeacher == false)
            {
                throw new UnauthorizedAccessException("شما دسترسی به این سوالات ندارید.");
            }
            var validationResult = await _validator.ValidateAsync(request.UpdateTrueOrFalseAnswerTeacherDTO);
            if (validationResult.IsValid == false)
            {
                var errprs = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errprs);
            }
            await _trueOrFalseAnswersRepository.UpdateAsync(request.UpdateTrueOrFalseAnswerTeacherDTO.Id, request.UpdateTrueOrFalseAnswerTeacherDTO);
        }
    }
}
