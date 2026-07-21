using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveQuestion.Validation;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion.Validation;
using OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using FluentValidation;

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Handler.Commands
{
    public class CreateMultipleChoiceQuestionRequestHandler : IRequestHandler<CreateMultipleChoiceQuestionRequest, int>
    {
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;
        private readonly IValidator<CreateMultipleChoiceQuestionDTO> _validator;
        public CreateMultipleChoiceQuestionRequestHandler(IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository,
            IValidator<CreateMultipleChoiceQuestionDTO> validator)
        {
            _multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
            _validator = validator;
        }
        public async Task<int> Handle(CreateMultipleChoiceQuestionRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.CreateMultipleChoiceQuestionDTO);
            if (validationResult.IsValid == false)
            {
                var validtionErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(validtionErrors);
            }
            var result = await _multipleChoiceQuestionRepository.AddAsync<CreateMultipleChoiceQuestionDTO>(request.CreateMultipleChoiceQuestionDTO);
            return result.Id;
        }
    }
}
