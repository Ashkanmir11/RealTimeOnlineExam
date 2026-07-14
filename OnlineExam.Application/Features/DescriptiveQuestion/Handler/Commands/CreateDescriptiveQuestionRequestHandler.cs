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
namespace OnlineExam.Application.Features.DescriptiveQuestion.Handler.Commands
{
    public class CreateDescriptiveQuestionRequestHandler : IRequestHandler<CreateDescriptiveQuestionRequest>
    {
        private readonly IExamRepository _examRepository;
        private readonly IDescriptiveQuestionRepository _descriptiveQuestionRepository;
        public CreateDescriptiveQuestionRequestHandler(IExamRepository examRepository, IDescriptiveQuestionRepository descriptiveQuestionRepository)
        {
            _examRepository = examRepository;
            _descriptiveQuestionRepository = descriptiveQuestionRepository;
        }

        public async Task Handle(CreateDescriptiveQuestionRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateDescriptiveQuestionValidation(_examRepository);
            var validationResult = await validator.ValidateAsync(request.CreateDescriptiveQuestionDTO);
            if(validationResult.IsValid==false)
            {
                throw new ValidationException(ListToStringHelper.CreateString(validationResult.Errors.Select(e => e.ErrorMessage).ToList()));
            }
            await _descriptiveQuestionRepository.AddAsync<CreateDescriptiveQuestionDTO>(request.CreateDescriptiveQuestionDTO);
        }
    }
}
