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

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Handler.Commands
{
    public class CreateMultipleChoiceQuestionRequestHandler : IRequestHandler<CreateMultipleChoiceQuestionRequest>
    {
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;
        private readonly IExamRepository _examRepository;
        public CreateMultipleChoiceQuestionRequestHandler(IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository, IExamRepository examRepository)
        {
            _multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
            _examRepository = examRepository;
        }
        public async Task Handle(CreateMultipleChoiceQuestionRequest request, CancellationToken cancellationToken)
        {
            var validtor = new CreateMultipleChoiceQuestionValidation(_examRepository);
            var validationResult = await validtor.ValidateAsync(request.CreateMultipleChoiceQuestionDTO);
            if (validationResult.IsValid == false)
            {
                var validtionErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationException(validtionErrors);
            }

            await _multipleChoiceQuestionRepository.AddAsync<CreateMultipleChoiceQuestionDTO>(request.CreateMultipleChoiceQuestionDTO);
        }
    }
}
