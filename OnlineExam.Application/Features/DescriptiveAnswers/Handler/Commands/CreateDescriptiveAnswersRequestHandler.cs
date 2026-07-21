using MediatR;
using OnlineExam.Application.DTOs.DescriptiveAnswers.Validation;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using FluentValidation;
using OnlineExam.Application.Features.ExamAttampt.Request.Queries;

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
                throw new UnauthorizedAccessException("آزمون به پایان رسیده است.");
            }
            await _DescriptiveAnswersRepository.AddAsync<CreateDescriptiveAnswersDTO>(request.CreateDescriptiveAnswersDTO);
        }
    }
}
