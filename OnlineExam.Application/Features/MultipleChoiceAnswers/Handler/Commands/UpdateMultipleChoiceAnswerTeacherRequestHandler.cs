using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands;
using OnlineExam.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Handler.Commands
{
    public class UpdateMultipleChoiceAnswerTeacherRequestHandler : IRequestHandler<UpdateMultipleChoiceAnswerTeacherRequest>
    {
        private readonly IValidator<UpdateMultipleChoiceAnswerTeacherDTO> _validator;
        private readonly IAuthServices _authServices;
        private readonly IClassRoomRepository _classRepository;
        private readonly IMultipleChoiceAnswersRepository _multipleChoiceAnswerRepository;
        private readonly IQuestionRepository _questionRepository;
        public UpdateMultipleChoiceAnswerTeacherRequestHandler(IValidator<UpdateMultipleChoiceAnswerTeacherDTO> validator, IAuthServices authServices
            , IClassRoomRepository classRepository, IMultipleChoiceAnswersRepository multipleChoiceAnswerRepository, IQuestionRepository questionRepository)
        {
            _validator = validator;
            _authServices = authServices;
            _classRepository = classRepository;
            _multipleChoiceAnswerRepository = multipleChoiceAnswerRepository;
            _questionRepository = questionRepository;
        }

        public async Task Handle(UpdateMultipleChoiceAnswerTeacherRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<string>();
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var question = await _questionRepository.GetByQuestionDetailIdAsync(QuestionType.MultipleChoice, request.Id);
            if (question == null)
            {
                throw new NotFoundException("سوال یافت نشد.");
            }
            if (request.UpdateMultipleChoiceAnswerTeacherDTO.StudentScore > question.TotalScore)
            {
                errors.Add("نمره نباید بیشتر از نمره سوال باشد.");
            }

            var isTeacher = await _classRepository.IsUserTeacherByExamIdAsync(request.UpdateMultipleChoiceAnswerTeacherDTO.ExamId, currentUser);
            if (isTeacher == false)
            {
                throw new AccessForbiddenException("شما دسترسی به این سوالات ندارید.");
            }
            var validationResult = await _validator.ValidateAsync(request.UpdateMultipleChoiceAnswerTeacherDTO);
            if (validationResult.IsValid == false)
            {
                errors.AddRange(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            if(errors.Count>0)
            {
                throw new Application.Exceptions.ValidationException(errors);
            }
            await _multipleChoiceAnswerRepository.UpdateAsync(request.Id, request.UpdateMultipleChoiceAnswerTeacherDTO);
        }
    }
}
