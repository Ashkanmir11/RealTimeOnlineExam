using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers;
using OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers.Validation;
using OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Helper;

namespace OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Handler.Commands
{
    public class UpdateMultipleChoiceQuestionAnswerRequestHandler : IRequestHandler<UpdateMultipleChoiceQuestionAnswerRequest>
    {
        private readonly IMultipleChoiceQuestionAnswersRepository _multipleChoiceQuestionAnswersRepository;
        public UpdateMultipleChoiceQuestionAnswerRequestHandler(IMultipleChoiceQuestionAnswersRepository multipleChoiceQuestionAnswersRepository)
        {
            _multipleChoiceQuestionAnswersRepository = multipleChoiceQuestionAnswersRepository;
        }
        public async Task Handle(UpdateMultipleChoiceQuestionAnswerRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMultipleChoiceQuestionAnswerValidation(_multipleChoiceQuestionAnswersRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateMultipleChoiceQuestionAnswerDTO);
            if(validationResult.IsValid==false)
            {
                var massage = ListToStringHelper.CreateString(validationResult.Errors.Select(e=>e.ErrorMessage).ToList());
                throw new ValidationException(massage);
            }
            await _multipleChoiceQuestionAnswersRepository.UpdateAsync(request.UpdateMultipleChoiceQuestionAnswerDTO.Id, request.UpdateMultipleChoiceQuestionAnswerDTO);
        }
    }
}
