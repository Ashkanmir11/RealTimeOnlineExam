using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion.Validation;
using OnlineExam.Application.DTOs.TrueOrFalseQuestionAnswers.Validation;
using OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Handler.Commands
{
    public class UpdateTrueOrFalseQuestionAnswerRequestHandler : IRequestHandler<UpdateTrueOrFalseQuestionAnswerRequest>
    {
        private readonly ITrueOrFalseQuestionAnswersRepository _trueOrFalseQuestionAnswersRepository;
        public UpdateTrueOrFalseQuestionAnswerRequestHandler(ITrueOrFalseQuestionAnswersRepository trueOrFalseQuestionAnswersRepository)
        {
            _trueOrFalseQuestionAnswersRepository = trueOrFalseQuestionAnswersRepository;
        }
        public async Task Handle(UpdateTrueOrFalseQuestionAnswerRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTrueOrFalseQuestionAnswerValidation(_trueOrFalseQuestionAnswersRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateTrueOrFalseQuestionAnswerDTO);
            if (validationResult.IsValid == false)
            {
                var massage = ListToStringHelper.CreateString(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                throw new ValidationException(massage);
            }
            await _trueOrFalseQuestionAnswersRepository.UpdateAsync(request.UpdateTrueOrFalseQuestionAnswerDTO.Id, request.UpdateTrueOrFalseQuestionAnswerDTO);
        }
    }
}
