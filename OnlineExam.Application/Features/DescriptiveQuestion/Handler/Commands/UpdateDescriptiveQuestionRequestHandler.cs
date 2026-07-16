using MediatR;
using OnlineExam.Application.DTOs.DescriptiveQuestion.Validation;
using OnlineExam.Application.Features.DescriptiveQuestion.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveQuestion;

namespace OnlineExam.Application.Features.DescriptiveQuestion.Handler.Commands
{
    public class UpdateDescriptiveQuestionRequestHandler : IRequestHandler<UpdateDescriptiveQuestionRequest>
    {
        private readonly IDescriptiveQuestionRepository _descriptiveQuestionRepository;
        public UpdateDescriptiveQuestionRequestHandler(IDescriptiveQuestionRepository descriptiveQuestionRepository)
        {
            _descriptiveQuestionRepository = descriptiveQuestionRepository;
        }
        public async Task Handle(UpdateDescriptiveQuestionRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDescriptiveQuestionValidation(_descriptiveQuestionRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateDescriptiveQuestionDTO);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            await _descriptiveQuestionRepository.UpdateAsync(request.UpdateDescriptiveQuestionDTO.Id, request.UpdateDescriptiveQuestionDTO);
        }
    }
}
