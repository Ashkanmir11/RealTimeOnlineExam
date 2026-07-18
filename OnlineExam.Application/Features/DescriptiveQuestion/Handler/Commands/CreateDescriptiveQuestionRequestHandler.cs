using MediatR;
using OnlineExam.Application.Features.DescriptiveQuestion.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.DTOs.DescriptiveQuestion.Validation;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Helper;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using FluentValidation;
namespace OnlineExam.Application.Features.DescriptiveQuestion.Handler.Commands
{
    public class CreateDescriptiveQuestionRequestHandler : IRequestHandler<CreateDescriptiveQuestionRequest, int>
    {
        private readonly IExamRepository _examRepository;
        private readonly IDescriptiveQuestionRepository _descriptiveQuestionRepository;
        private readonly IValidator<CreateDescriptiveQuestionDTO> _validator;
        public CreateDescriptiveQuestionRequestHandler(IExamRepository examRepository, IDescriptiveQuestionRepository descriptiveQuestionRepository, IValidator<CreateDescriptiveQuestionDTO> validator)
        {
            _examRepository = examRepository;
            _descriptiveQuestionRepository = descriptiveQuestionRepository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateDescriptiveQuestionRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.CreateDescriptiveQuestionDTO);
            if (validationResult.IsValid == false)
            {
                throw new Application.Exceptions.ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            var result = await _descriptiveQuestionRepository.AddAsync<CreateDescriptiveQuestionDTO>(request.CreateDescriptiveQuestionDTO);
            return result.Id;
        }
    }
}
