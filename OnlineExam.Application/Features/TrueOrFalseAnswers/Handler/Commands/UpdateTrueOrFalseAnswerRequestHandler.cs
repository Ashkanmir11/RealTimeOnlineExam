using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion.Validation;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers.Validation;
using OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Handler.Commands
{
    public class UpdateTrueOrFalseAnswerRequestHandler : IRequestHandler<UpdateTrueOrFalseAnswerRequest>
    {
        private readonly ITrueOrFalseAnswersRepository _TrueOrFalseAnswersRepository;
        public UpdateTrueOrFalseAnswerRequestHandler(ITrueOrFalseAnswersRepository TrueOrFalseAnswersRepository)
        {
            _TrueOrFalseAnswersRepository = TrueOrFalseAnswersRepository;
        }
        public async Task Handle(UpdateTrueOrFalseAnswerRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTrueOrFalseAnswerValidation(_TrueOrFalseAnswersRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateTrueOrFalseQuestionAnswerDTO);
            if (validationResult.IsValid == false)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationException(errors);
            }
            await _TrueOrFalseAnswersRepository.UpdateAsync(request.UpdateTrueOrFalseQuestionAnswerDTO.Id, request.UpdateTrueOrFalseQuestionAnswerDTO);
        }
    }
}
