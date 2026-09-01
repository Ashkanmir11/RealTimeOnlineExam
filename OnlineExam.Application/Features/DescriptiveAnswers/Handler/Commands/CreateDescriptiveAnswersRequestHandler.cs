using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Handler.Commands
{
    public class CreateDescriptiveAnswersRequestHandler : IRequestHandler<CreateDescriptiveAnswersRequest>
    {
        private readonly IDescriptiveAnswersRepository _DescriptiveAnswersRepository;
        private readonly IAuthServices _authServices;
        private readonly IValidator<CreateDescriptiveAnswersDTO> _validator;
        private readonly IExamAttamptRepository _examAttamptRepository;

        public CreateDescriptiveAnswersRequestHandler(IDescriptiveAnswersRepository DescriptiveAnswersRepository,
            IAuthServices authServices, IValidator<CreateDescriptiveAnswersDTO> validator
            , IExamAttamptRepository examAttamptRepository)
        {
            _DescriptiveAnswersRepository = DescriptiveAnswersRepository;
            _authServices = authServices;
            _validator = validator;
            _examAttamptRepository = examAttamptRepository;
        }

        public async Task Handle(CreateDescriptiveAnswersRequest request, CancellationToken cancellationToken)
        {
            request.CreateDescriptiveAnswersDTO.StudentId = await _authServices.GetCurrentUserIdAsync();
            var validationResult = await _validator.ValidateAsync(request.CreateDescriptiveAnswersDTO);
            if (validationResult.IsValid == false)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);
            }



            var ExamEnded = await _examAttamptRepository.ExamEndedAsync(request.CreateDescriptiveAnswersDTO.ExamId, request.CreateDescriptiveAnswersDTO.StudentId);
            if (ExamEnded)
            {
                throw new AccessForbiddenException("آزمون به پایان رسیده است.");
            }
            await _DescriptiveAnswersRepository.AddAsync<CreateDescriptiveAnswersDTO>(request.CreateDescriptiveAnswersDTO);
        }
    }
}
