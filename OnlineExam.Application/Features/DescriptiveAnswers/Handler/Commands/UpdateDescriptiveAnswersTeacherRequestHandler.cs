using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands;
using OnlineExam.Domain.Enums;
namespace OnlineExam.Application.Features.DescriptiveAnswers.Handler.Commands
{
    public class UpdateDescriptiveAnswersTeacherRequestHandler : IRequestHandler<UpdateDescriptiveAnswersTeacherRequest>
    {
        private readonly IValidator<UpdateDescriptiveAnswersTeacherDTO> _validator;
        private readonly IAuthServices _authServices;
        private readonly IClassRoomRepository _classRepository;
        private readonly IDescriptiveAnswersRepository _descriptiveAnswersRepository;
        private readonly IQuestionRepository _questionRepository;

        public UpdateDescriptiveAnswersTeacherRequestHandler(IValidator<UpdateDescriptiveAnswersTeacherDTO> validator, IAuthServices authServices
            , IClassRoomRepository classRepository, IDescriptiveAnswersRepository descriptiveAnswersRepository, IQuestionRepository questionRepository)
        {
            _validator = validator;
            _authServices = authServices;
            _classRepository = classRepository;
            _descriptiveAnswersRepository = descriptiveAnswersRepository;
            _questionRepository = questionRepository;
        }

        public async Task Handle(UpdateDescriptiveAnswersTeacherRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<string>();
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var isTeacher = await _classRepository.IsUserTeacherByExamIdAsync(request.updateDescriptiveAnswersTeacherDTO.ExamId, currentUser);
            if (isTeacher == false)
            {
                throw new AccessForbiddenException("شما دسترسی به این سوالات ندارید.");
            }

            var answerExist = await _descriptiveAnswersRepository.ExistAsync(request.Id);
            if (answerExist == false)
            {
                throw new NotFoundException("پاسخ یافت نشد.");
            }


            var question = await _questionRepository.GetByQuestionDetailIdAsync(QuestionType.Descriptive, request.Id);
            if (question == null)
            {
                throw new NotFoundException("سوال یافت نشد.");
            }
            if (request.updateDescriptiveAnswersTeacherDTO.StudentScore > question.TotalScore)
            {
                errors.Add("نمره نباید از نمره سوال بیشتر باشد.");
            }

            var validationResult = await _validator.ValidateAsync(request.updateDescriptiveAnswersTeacherDTO);
            if (validationResult.IsValid == false)
            {
                errors.AddRange(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            if (errors.Count > 0)
            {
                throw new Application.Exceptions.ValidationException(errors);
            }


            await _descriptiveAnswersRepository.UpdateAsync(request.Id, request.updateDescriptiveAnswersTeacherDTO);
        }
    }
}
