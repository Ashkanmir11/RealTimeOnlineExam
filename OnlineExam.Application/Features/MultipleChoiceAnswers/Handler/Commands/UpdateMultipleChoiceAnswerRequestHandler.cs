using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers.Validation;
using OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Helper;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Handler.Commands
{
    public class UpdateMultipleChoiceAnswerRequestHandler : IRequestHandler<UpdateMultipleChoiceAnswerRequest>
    {
        private readonly IMultipleChoiceAnswersRepository _MultipleChoiceAnswersRepository;
        public UpdateMultipleChoiceAnswerRequestHandler(IMultipleChoiceAnswersRepository MultipleChoiceAnswersRepository)
        {
            _MultipleChoiceAnswersRepository = MultipleChoiceAnswersRepository;
        }
        public async Task Handle(UpdateMultipleChoiceAnswerRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMultipleChoiceAnswerValidation(_MultipleChoiceAnswersRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateMultipleChoiceQuestionAnswerDTO);
            if(validationResult.IsValid==false)
            {
                var errors = validationResult.Errors.Select(e=>e.ErrorMessage).ToList();
                throw new ValidationException(errors);
            }
            await _MultipleChoiceAnswersRepository.UpdateAsync(request.UpdateMultipleChoiceQuestionAnswerDTO.Id, request.UpdateMultipleChoiceQuestionAnswerDTO);
        }
    }
}
