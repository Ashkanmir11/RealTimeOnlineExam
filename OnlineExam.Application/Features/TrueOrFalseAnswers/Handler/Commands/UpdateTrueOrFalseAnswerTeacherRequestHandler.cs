using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands;
using static System.Formats.Asn1.AsnWriter;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Handler.Commands
{
    public class UpdateTrueOrFalseAnswerTeacherRequestHandler : IRequestHandler<UpdateTrueOrFalseAnswerTeacherRequest>
    {
        private readonly IValidator<UpdateTrueOrFalseAnswerTeacherDTO> _validator;
        private readonly IAuthServices _authServices;
        private readonly IClassRoomRepository _classRepository;
        private readonly ITrueOrFalseAnswersRepository _trueOrFalseAnswersRepository;
        private readonly IQuestionRepository _questionRepository;

        public UpdateTrueOrFalseAnswerTeacherRequestHandler(IValidator<UpdateTrueOrFalseAnswerTeacherDTO> validator, IAuthServices authServices
            , IClassRoomRepository classRepository, ITrueOrFalseAnswersRepository trueOrFalseAnswersRepository, IQuestionRepository quesitonRepository)
        {
            _validator = validator;
            _authServices = authServices;
            _classRepository = classRepository;
            _trueOrFalseAnswersRepository = trueOrFalseAnswersRepository;
            _questionRepository = quesitonRepository;
        }
        public async Task Handle(UpdateTrueOrFalseAnswerTeacherRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<string>();
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var question = await _questionRepository.GetByQuestionDetailIdAsync(true, false, false, request.UpdateTrueOrFalseAnswerTeacherDTO.ExamId);
            if (question == null)
            {
                throw new NotFoundException("سوال یافت نشد.");
            }
            if (request.UpdateTrueOrFalseAnswerTeacherDTO.StudentScore > question.TotalScore)
            {
                errors.Add("نمره نباید از نمره سوال بیشتر باشد.");
            }
            var isTeacher = await _classRepository.IsUserTeacherByExamIdAsync(request.UpdateTrueOrFalseAnswerTeacherDTO.ExamId, currentUser);
            if (isTeacher == false)
            {
                throw new AccessForbiddenException("شما دسترسی به این سوالات ندارید.");
            }
            var validationResult = await _validator.ValidateAsync(request.UpdateTrueOrFalseAnswerTeacherDTO);
            if (validationResult.IsValid == false)
            {
                errors.AddRange(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                throw new Application.Exceptions.ValidationException(errors);
            }
            await _trueOrFalseAnswersRepository.UpdateAsync(request.Id, request.UpdateTrueOrFalseAnswerTeacherDTO);
        }
    }
}
